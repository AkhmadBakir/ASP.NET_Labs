using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using StudentsBook.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace StudentsBook.Controllers
{
    public class HomeController : Controller
    {

        private readonly StudentContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StudentContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            GiveStudents();
            //var allStudents = db.Students.ToList<Student>();
            //ViewBag.Students = allStudents;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GiveStudents()
        {
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            GiveStudents();
            //var allStudents = db.Students.ToList<Student>();
            //ViewBag.Students = allStudents;
            return View();
        }

        [HttpPost]
        public string CreateStudent(Student newStudent)
        {
            // Добавляем новую заявку в БД
            db.Students.Add(newStudent);
            // Сохраняем в БД все изменения
            db.SaveChanges();
            return "Студент " + newStudent.Name + "добавлен.";

        }

        public IActionResult Excel()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Users");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Id";
            worksheet.Cell(currentRow, 2).Value = "Name";
            worksheet.Cell(currentRow, 3).Value = "Subject1";
            worksheet.Cell(currentRow, 4).Value = "Subject2";
            worksheet.Cell(currentRow, 5).Value = "Subject3";
            worksheet.Cell(currentRow, 6).Value = "Subject4";
            worksheet.Cell(currentRow, 7).Value = "Rating";
            foreach (var user in db.Students)
            {
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = user.Id;
                worksheet.Cell(currentRow, 2).Value = user.Name;
                worksheet.Cell(currentRow, 3).Value = user.Subject1;
                worksheet.Cell(currentRow, 4).Value = user.Subject2;
                worksheet.Cell(currentRow, 5).Value = user.Subject3;
                worksheet.Cell(currentRow, 6).Value = user.Subject4;
                worksheet.Cell(currentRow, 7).Value = user.Rating;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Список студентов.xlsx");
        }
        public ActionResult GoodStudents(int Id)
        {
            var allStudents = db.Students.OrderBy(x => x.Rating).ToList();
            var goodStudets = allStudents.TakeLast(5);
            return PartialView(goodStudets);
        }
        public ActionResult BadStudents(int Id)
        {
            var allStudents = db.Students.OrderBy(x => x.Rating).ToList();
            var badStudets = allStudents.Take(5);
            return PartialView(badStudets);
        }
    }
}
