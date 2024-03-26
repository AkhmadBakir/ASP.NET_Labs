using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public Product Product { get; set; }

        public string? MessageRezult { get; private set; }

        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            var result = price * (decimal?)0.18;
            MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }
        public void OnGet(string name, decimal? price)
        {
            MessageRezult = "��� ������ ����� ���������� ������";
        }
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discont} ������ ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }
        public void OnPostCard(string name, decimal? price, double card)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            var result = price * (decimal?)5 / 100;
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� �� ����� ����� ����� {card} ������ ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }
    }
}
