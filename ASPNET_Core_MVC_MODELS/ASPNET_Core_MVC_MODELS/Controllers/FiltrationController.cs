#define via_WebApi
//#define without_WebApi

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNET_Core_MVC_MODELS.Models;        // ВАЖНО - подключаем пространства имён!!
using ASPNET_Core_MVC_MODELS.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text;
using System.IO;
using RestSharp;


namespace ASPNET_Core_MVC_MODELS.Controllers
{
    public class FiltrationController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
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

#if without_WebApi  // Получение списка юзеров с фильтрацией с помощью нижеследующего метода
        public IActionResult GetUsers(string sortOrder, string searchNameString, int searchAge)
        {
            ViewData["NameSortParm"] = "name_desc";         // устанавливаем какие-то значения параметров сортировки, чтоб они не были пустыми. Потом эти значения будут передаваться из View в этот метод в виде переменной sortOrder
            ViewData["AgeSortParm"] = "age_desc";
            ViewData["IdSortParm"] = "id_desc";
            List<int> ages = users.Select(u => u.Age).Distinct().ToList();      // возрасты в представлении будем выбирать из выпадающего списка
            ViewData["Ages"] = new SelectList(ages);

        #region                     ФИЛЬТРАЦИЯ
                // устанавливаем фильтр, чтоб возвратить его в View
            ViewData["FilterByName"] = string.IsNullOrEmpty(searchNameString) ? "" : searchNameString;
            ViewData["FilterByAge"] = searchAge == 0 ? 0 : searchAge;

            // делаем предварительную фильтрацию юзеров по пришедшей строке searchNameString
            if (!string.IsNullOrEmpty(searchNameString))
            {
                users = users.Where(u => u.Name.Contains(searchNameString)).ToList();        // если это EntityFramework и идёт обращение к БД, то .ToList() - не надо
            }
            // делаем предварительную фильтрацию юзеров по пришедшей строке searchAgeString
            if (searchAge != 0)
            {
                users = users.Where(u => u.Age == searchAge).ToList();        // если это EntityFramework и идёт обращение к БД, то .ToList() - не надо
            }
        #endregion
            // делаем сортировку
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Name).ToList();
                    ViewData["NameSortParm"] = "name_asc";
                    break;
                case "name_asc":
                    users = users.OrderBy(s => s.Name).ToList();
                    ViewData["NameSortParm"] = "name_desc";
                    break;
                case "age_desc":
                    users = users.OrderByDescending(s => s.Age).ToList();
                    ViewData["AgeSortParm"] = "age_asc";
                    break;
                case "age_asc":
                    users = users.OrderBy(s => s.Age).ToList();
                    ViewData["AgeSortParm"] = "age_desc";
                    break;
            }
            return View(users);
        }
#endif

#if via_WebApi      //Получение списка юзеров с фильтрацией с помощью WebApi через сторонний сервис - проект сервиса лежит в папке  ...\ASPNet\WebApi
        public IActionResult GetUsers(string sortOrder, string searchNameString, int searchAge)
        {
            ViewData["NameSortParm"] = "name_desc";         // устанавливаем какие-то значения параметров сортировки, чтоб они не были пустыми. Потом эти значения будут передаваться из View в этот метод в виде переменной sortOrder
            ViewData["AgeSortParm"] = "age_desc";
            ViewData["IdSortParm"] = "id_desc";
            List<int> ages = users.Select(u => u.Age).Distinct().ToList();      // возрасты в представлении будем выбирать из выпадающего списка
            ViewData["Ages"] = new SelectList(ages);
                // устанавливаем фильтр, чтоб возвратить его в View
            ViewData["FilterByName"] = string.IsNullOrEmpty(searchNameString) ? "" : searchNameString;
            ViewData["FilterByAge"] = searchAge == 0 ?0: searchAge;


            Dictionary<string, string> body = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(searchNameString))
            {
                body.Add("searchNameString", searchNameString);
            }
            if (searchAge != 0)
            {
                body.Add("searchAge", searchAge.ToString());
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                body.Add("sortOrder", sortOrder);
            }

            //инвертируем сортировку
            switch (sortOrder)
            {
                case "name_desc":
                    ViewData["NameSortParm"] = "name_asc";
                    break;
                case "name_asc":
                    ViewData["NameSortParm"] = "name_desc";
                    break;
                case "age_desc":
                    ViewData["AgeSortParm"] = "age_asc";
                    break;
                case "age_asc":
                    ViewData["AgeSortParm"] = "age_desc";
                    break;
            }

            string requestBody = GetRequestBodyJSON(body);
            var client = new RestClient("http://localhost:5549/api/Users");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("method", "POST");
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<User> userList = SimpleJson.DeserializeObject<List<User>>(response.Content);
            //List<User> users = SimpleJson.DeserializeObject(response.Content, typeof(List<User>));
            return View(userList);
        }
#endif



        private string GetRequestBodyJSON(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            string[] keys = dic.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                
                if(i< keys.Length - 1)
                    sb.Append("\"" + keys[i] + "\":" + "\"" + dic[keys[i]] + "\",");
                else
                    sb.Append("\"" + keys[i] + "\":" + "\"" + dic[keys[i]] + "\"");
            }
            
            sb.Append("}");          
            return sb.ToString(); ;
        }
    }
}