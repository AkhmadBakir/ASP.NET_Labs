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
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = price * (decimal?)0.18;
            MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
        public void OnGet(string name, decimal? price)
        {
            MessageRezult = "Для товара можно определить скидку";
        }
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
        public void OnPostCard(string name, decimal? price, double card)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = price * (decimal?)5 / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой по Вашей карте номер {card} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
    }
}
