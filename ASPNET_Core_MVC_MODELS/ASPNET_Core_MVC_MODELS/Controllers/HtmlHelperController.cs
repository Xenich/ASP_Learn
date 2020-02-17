using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNET_Core_MVC_MODELS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_Core_MVC_MODELS.Controllers
{
    public class HtmlHelperController : Controller
    {
        // Основная вьюха с HtmlHelper-ами
        public ActionResult Index()
        {
            return View();
        }

//*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*          хелперы простых элементов - текстовые поля, радиобаттоны и чекбоксы            *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*        
        // вьюха с формой с простыми элементами 
        [HttpGet]
        public ActionResult SimpleHTMLHelperForm()
        {
            return View();
        }

            // POST - запрос из формы с простыми хелперами
        [HttpPost]
        public string SimpleHTMLHelperForm(string Name,int Price, string textAREA, string hidden, string UserPassword, string color,bool Enable)
        {
            return "Возвращенно из контроллера на POST-запрос SimpleHTMLHelperForm:" + Environment.NewLine + 
            "Name: " + Name + ", Price: " + Price+ ", textAREA: " + textAREA+ ", hidden: " + hidden + ", UserPassword: " + UserPassword+ ", color: " + color+ ", Enable: " + Enable;

        }

//*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*         хелперы типа select         *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            // вьюха с формой с элементами типа select
        [HttpGet]
        public ActionResult HTMLHelperSelect()
        {
                // создадим коллекцию юзеров и передадим их в представление - там будем с ними работать
            List<User> users = new List<User>()
            {
                new User{Id=1, Name="Tom", Age=20},
                new User{Id=2, Name="Alice", Age=30},
                new User{Id=3, Name="Sam", Age=40},
                new User{Id=4, Name="Bob", Age=50}
            };

            // User selected = new User { Id = 5, Name = "selected", Age = 50 }; users.Add(selected);
            ViewBag.Users = new SelectList(users, "Id", "Name", 2);  // не забыть подключить Microsoft.AspNetCore.Mvc.Rendering; в конструктор объекта SelectList
                                                                   // передаём "Id" - назв. св-ва модели User, кот. будет использоваться в кач-ве значения, 2 - Selected Value(можно и не использовать) и
                                                                   // "Name" - назв. св-ва модели User, кот. будет использоваться для отображения в списке       в представлении это будет: <option value="1">Tom</option> и т.д. ...
            return View();
        }

            // POST - запрос из формы с элементами типа select
        [HttpPost]
        public string HTMLHelperSelect(string user, int newUsers, int ListUsers, int daytime)
        {           
            return "Возвращенно из контроллера на POST-запрос HTMLHelperSelect:" + Environment.NewLine +
                       "user: " + user + ", newUser: " + newUsers + ", ListUsers: " + ListUsers + ", daytime: " + Enum.GetValues(typeof(TimeOfDay)).GetValue(daytime);
        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*         Строго типизированные хелперы        *-*-*-*-*-*-*-*-*-*-*-*-*
                                                                //Строго типизированные хелперы могут использоваться только в строго типизированных представлениях, а тип модели, которая передается в хелпер, 
                                                                //должен быть тем же самым, что указан для всего представления с помощью директивы @model.
        //
        [HttpGet]
        public ActionResult HTMLHelpersFOR()
        {
            return View();     // передаём модель в представление (на сторону клиента) Views/Htmlhelper/HtmlhelpersFOR.cshtml
        }
        //
        [HttpPost]
        public string HTMLHelpersFOR(User u)
        {
            return $"Передано методом GET в виде набора полей в контроллер: ID: {u.Id}, Name: {u.Name}, Age: {u.Age}";
        }

    }



}