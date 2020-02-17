

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiASP.Models;
using WebApiASP.Inputs;         //в этом неймспейсе находится класс с данными по фильтру
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace WebApiASP.Controllers
{
    [Route("api/[controller]")]     // атрибут маршрутизации, который указывает, как контроллер будет сопоставляться с запросами. 
    [ApiController]                 // позволяет использовать ряд дополнительных возможностей, в частности, в плане привязки модели и ряд других
    public class UsersController : ControllerBase
    {
        List<User> users = new List<User>() {
                new User{Id=1, Name="Vasya", Age=20},
                new User{Id=2, Name="Kolya", Age=30},
                new User{Id=3, Name="Serega", Age=20},
                new User{Id=4, Name="Denis", Age=25},
                new User{Id=5, Name="Petya", Age=30},
                new User{Id=6, Name="Vasya", Age=20},
                new User{Id=7, Name="Vasya", Age=25},
                new User{Id=8, Name="Petya", Age=20},
                new User{Id=9, Name="Serega", Age=30},
                new User{Id=10, Name="Kolya", Age=20},
            };

        // POST api/users   название метода - это тип запроса - POST.     Обращение к этому методу и сторонних приложенй происходит например так: new RestClient("http://localhost:5549/api/Users");...  порт можно указать в настройках
        [HttpPost]
        public ActionResult<IEnumerable<User>> Post([FromBody] Filter filter)       // в теле запроса приходят параметры с именами - имена свойства класса Filter   [FromBody]    attribute is for JSON/XML
        {
            var r = Request;
            if (ModelState.IsValid)
            {
                bool valid = true;
            }
                // делаем предварительную фильтрацию юзеров по пришедшей строке searchNameString
            if (!string.IsNullOrEmpty(filter.searchNameString))
            {
                users = users.Where(u => u.Name.Contains(filter.searchNameString)).ToList();        // если это EntityFramework и идёт обращение к БД, то .ToList() - не надо
            }
                // делаем предварительную фильтрацию юзеров по пришедшей строке searchAge
            if (filter.searchAge != 0)
            {
                users = users.Where(u => u.Age == filter.searchAge).ToList();        // если это EntityFramework и идёт обращение к БД, то .ToList() - не надо
            }

                // делаем сортировку
            switch (filter.sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Name).ToList();
                    
                    break;
                case "name_asc":
                    users = users.OrderBy(s => s.Name).ToList();
                    
                    break;
                case "age_desc":
                    users = users.OrderByDescending(s => s.Age).ToList();
                    
                    break;
                case "age_asc":
                    users = users.OrderBy(s => s.Age).ToList();
                    
                    break;
            }
            
            return (users);
        }

        #region Примеры GET-запросов
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return users;
        }

        //// GET api/users/5
        //[HttpGet("{id}")]
        //public ActionResult<User> Get(int id)
        //{
        //    return users.Where(u => u.Id == id).FirstOrDefault();
        //}

        //// GET api/users/Vasya/1
        //[HttpGet("{name}/{age}")]
        //public ActionResult<IEnumerable<User>> Get(string name, int age)
        //{
        //    return users.Where(u => u.Name == name).Where(u=>u.Age==age).ToList();
        //}
        #endregion


    }
}