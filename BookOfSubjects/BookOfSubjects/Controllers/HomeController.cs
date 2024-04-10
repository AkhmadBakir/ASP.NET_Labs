using BookOfSubjects.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookOfSubjects.Data;
using Microsoft.EntityFrameworkCore;

namespace BookOfSubjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly SubjectContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SubjectContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var allSubjects = db.Subjects.ToList<Subject>();
            ViewBag.Subjects = allSubjects;
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
    }
}
