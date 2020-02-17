using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNET_Core_MVC_MODELS.Models;

namespace ASPNET_Core_MVC_MODELS.Controllers
{
    public class PaginationController : Controller
    {
        public IActionResult Index()
        {
            var pageNumber = string.IsNullOrEmpty(HttpContext.Request.Query["page"]) ? 1 : int.Parse(HttpContext.Request.Query["page"]);
            int pageSize = 3;


            UserIndexViewModel uivm = GetUserListFromDB(pageNumber, pageSize);


            return View(uivm);
        }

        private UserIndexViewModel GetUserListFromDB(int page, int pageSize)
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

            List<User> listReturn = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();           
            PageViewModel pageViewModel = new PageViewModel(users.Count,page, pageSize);

            UserIndexViewModel userindex = new UserIndexViewModel() { Users = listReturn, PageViewModel = pageViewModel };

            return userindex;
        }
    }
}