using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiASP.Models;

namespace WebApiASP.Controllers
{
    [Route("api/[controller]")]         // Контроллер для тестирования фреймворка Knockout. Файл с knockout находться в папке ...\Programming\C#\ASPNet\KnockOut\
    [ApiController]
    public class KnockoutController : ControllerBase
    {

        [HttpPost("getResponse")]       // обращение к этому метод API:  http://localhost:5549/api/Knockout/getResponse
        public IActionResult Getresponse([FromForm]Ident ident)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok(new Simpleresponse() { login = ident.login, password = ident.password, data = ident.data });
        }

        [HttpPost("getManufacturers")]      
        public IActionResult GetManufacturers([FromForm]Ident ident)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");           //браузер пользователя, получив такой заголовок разрешает доступ к ресурсам этого домена, который не совпадает с текущим.
            if (ident.login == "Dima")
                return Ok(new HardResponce());
            else
                return Ok("wrongLogin");
        }

        [HttpPost("getProductsByManufacturerFilter")]
        public IActionResult GetProductsByManufacturerFilter([FromForm]inputFilterManufactrer input)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");

            string filterName = input.filterName;
            int Id = input.id;

            filterName = HttpContext.Request.Form["filterName"];
            int.TryParse(HttpContext.Request.Form["id"], out Id);

            List<Product> returnListOfProducts = new List<Product>();
            switch (filterName)
            {
                case "manuf":
                    returnListOfProducts = GetProductList((int)Id);
                    break;
            }
            return Ok(returnListOfProducts);
        }



        // что-то типа БД
        private List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>()
        {
            new Manufacturer() { Id = 1, Name = "Sumsung" },
            new Manufacturer() { Id = 2, Name = "Nokia" },
            new Manufacturer() { Id = 3, Name = "Xiaomi" },
            new Manufacturer() { Id = 4, Name = "IBM" }
        };
        private List<Product> Products { get; set; } = new List<Product>()
            {
                new Product(){Id=1, Name="Телевизор самс" , ManufacturerId = 1},
                new Product(){Id=2, Name="Ноутбук самс" , ManufacturerId = 1},
                new Product(){Id=3, Name="мышка самс" , ManufacturerId = 1},
                new Product(){Id=4, Name="принтер самс" , ManufacturerId = 1},
                new Product(){Id=5, Name="телевизор нокия" , ManufacturerId = 2},
                new Product(){Id=6, Name="Ноутбук нокия" , ManufacturerId = 2},
                new Product(){Id=7, Name="мышка нокия" , ManufacturerId = 2},
                new Product(){Id=8, Name="принтер нокия" , ManufacturerId = 2},
                new Product(){Id=9, Name="телевизор ксиаоми" , ManufacturerId = 3},
                new Product(){Id=10, Name="Ноутбук ксиаоми" , ManufacturerId =3 },
                new Product(){Id=11, Name="мышка ксиаоми" , ManufacturerId =3 },
                new Product(){Id=12, Name="принтер ксиаоми" , ManufacturerId =3 },
                new Product(){Id=13, Name="телевизор ibm" , ManufacturerId = 4},
                new Product(){Id=14, Name="Ноутбук ibm" , ManufacturerId = 4},
                new Product(){Id=15, Name="мышка ibm" , ManufacturerId = 4},
                new Product(){Id=16, Name="принтер ibm" , ManufacturerId = 4}
            };

        private List<Product> GetProductList(int manufacturerId)
        {
            return Products.Where(p => p.ManufacturerId == manufacturerId).ToList();
        }
    }

    public class Ident
    {
        public string login { get; set; }
        public string password { get; set; }
        public string[] data { get; set; }
    }

    public class inputFilterManufactrer
    {
        public string filterName;
        public int id;
    }

    public class Simpleresponse 
    {
        public string login { get; set; }
        public string password { get; set; }
        public string[] data { get; set; }
    }

    public class HardResponce 
    {
        public string Name { get; set; } = "Aristotel";
        public string LastName { get; set; } = "Diogen";
            //public string[] Manufacturers { get; set; } = new string[] { "Sumsung", "Nokia", "Xiaomi", "IBM" };
        public Manufacturer[] Manufacturers { get; set; } = new Manufacturer[] { new Manufacturer() { Id=1, Name = "Sumsung" }, new Manufacturer() { Id = 2, Name = "Nokia" }, new Manufacturer() { Id = 3, Name = "Xiaomi" }, new Manufacturer() { Id = 4, Name = "IBM" } };
        public int[] Quantity { get; set; } = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}