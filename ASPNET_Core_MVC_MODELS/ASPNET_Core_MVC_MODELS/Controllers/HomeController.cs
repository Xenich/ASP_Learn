using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using ASPNET_Core_MVC_MODELS.Models;        // ВАЖНО - подключаем пространства имён!!
using ASPNET_Core_MVC_MODELS.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_Core_MVC_MODELS.Controllers
{
    public class HomeController : Controller
    {  
            //
        public Company Index()
        {
            Company microsoft = new Company()
            {
                Name = "Microsoft",
                Employees = 10000
            };
            // string result = $"Name: {microsoft.Name}, Employees: {microsoft.Employees}";         return result;
            return microsoft;
        }

            // Переопределение имени метода аттрибутом [ActionName]
        [ActionName("Myattribute")]
        public string myAction()
        {

            return "Переопределение имени вызываемого метода с помощью аттрибута [ActionName(\"Myattribute\")]";
        }

#region        *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*     Передача модели в представление     *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        // Передача одиночной модели в представление
        public IActionResult SingleModel()          // View, соответствующее этому контроллеру - Home/SingleModel.cshtml
        {
            Game counterStrike = new Game()
            {
                Name = "Counter Strike",
                Platform = "Windows",
                Engine = "HL"
            };
            return View(counterStrike);     // передаём модель в представление (на сторону клиента) Views/Home/SingleModel.cshtml
        }

            // передача коллекции моделей в представление
        public IActionResult CollectionModel()          
        {
            List<Game> collection = new List<Game>();
            Game counterStrike = new Game()
            {
                Name = "Counter Strike",
                Platform = "Windows",
                Engine = "HL"
            };

            Game hl = new Game()
            {
                Name = "Half Life",
                Platform = "Windows",
                Engine = "HL"
            };

            Game massEffect = new Game()
            {
                Name = "Mass Effect",
                Platform = "Windows",
                Engine = "Unreal Engine"
            };

            collection.Add(counterStrike);
            collection.Add(hl);
            collection.Add(massEffect);

            return View(collection);     // передаём коллекцию моделей в представление (на сторону клиента) Views/Home/CollectionModel.cshtml
        }

            // передача группы коллекций моделей разного типа в представление
            // осуществляется с помощью ViewModel - классов, которые содержат списки различных моделей
        public IActionResult DifferentModelsCollection()
        {
            
            Game counterStrike = new Game()
            {
                Name = "Counter Strike",
                Platform = "Windows",
                Engine = "HL"
            };

            Game hl = new Game()
            {
                Name = "Half Life",
                Platform = "Windows",
                Engine = "HL"
            };
                // список экземпляров Game
            List<Game> gameCollection = new List<Game>();
            gameCollection.Add(counterStrike);
            gameCollection.Add(hl);

            Company microsoft = new Company()
            {
                Name = "Microsoft",
                Employees = 10000
            };

            Company apple = new Company()
            {
                Name = "Apple",
                Employees = 10000
            };
                // список экземпляров Company
            List<Company> companyCollection = new List<Company>();
            companyCollection.Add(microsoft);
            companyCollection.Add(apple);

            DifferentViewModels differentViewModels = new DifferentViewModels();
            differentViewModels.Companies = companyCollection;
            differentViewModels.Games = gameCollection;

            return View(differentViewModels);     // передаём ViewModels - коллекции моделей разных типов в представление (на сторону клиента) Views/Home/DifferentModelsCollection.cshtml
        }
#endregion


#region        *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*     Передача данных в контроллер из представления       //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // Основая страничка с формами из которой будет передаваться информация
        public IActionResult FormDataFromViewToController()
        {
            return View();
        }
                                     // ------------    Варианты:   -----------
            // 1) Передача данных в контроллер в виде набора полей
            // названия принимаемых параметров должны совпадать с атрибутом name инпутов в html-форме в представлении
        public string DataFromViewToControllerByFields(string name, string platform, string engine)
        {
            return $"Передано методом POST в виде набора полей в контроллер: Name: {name}, Platform: {platform}, Engine:{engine}";
        }

            // 2) Передача данных в контроллер в виде объекта
            // названия принимаемых параметров должны совпадать с атрибутом name инпутов в html-форме в представлении
        public string DataFromViewToControllerByObject(Game game)
        {
            return $"Передано методом POST в виде объекта в контроллер: Name: {game.Name}, Platform: {game.Platform}, Engine: {game.Engine}";
        }

            // 3) Передача данных в контроллер в виде набора объектов (например, массив)
            // названия принимаемых параметров должны совпадать с атрибутом name инпутов в html-форме в представлении
        public string DataFromViewToControllerByArrayOfObjects(Game[] games)     // контролер принимает массив объектов
        {
            string result= "Передано методом POST в виде массива объектов в контроллер:" + Environment.NewLine;
            foreach (Game game in games)
            {
                result+= $"Name: {game.Name}, Platform: {game.Platform}, Engine: {game.Engine}" + Environment.NewLine;
            }
            return result;
        }

            // 4) Получение данных из контекста запроса 
            // В контроллере доступен объект Request, у которого можно получить как данные строки запроса, так и данные отправленных форм
                // 4.1)
        public string DataFromContextByHref()           // Передача данных в контроллер с помощью контекста запроса из строки запроса - методом GET
        {
            string s;
            s = Request.Query.FirstOrDefault(p => p.Key == "param1").Value;
            int param1 = Int32.Parse(s);
            s = Request.Query.FirstOrDefault(p => p.Key == "param2").Value;
            int param2 = Int32.Parse(s);
            s = Request.Query.FirstOrDefault(p => p.Key == "param3").Value;
            int param3 = Int32.Parse(s);
            
            //return "param1: "+param1.ToString() + "; param2: " +  param2.ToString() + "; param3: " + param3.ToString()+".";
            return $"param1: {param1.ToString()}; param2: {param2.ToString()}; param3: {param3.ToString()}.";
        }
                
                // 4.2
        public string DataFromContextByForm()           //Передача данных в контроллер с помощью контекста запроса из формы - методом POST
        {
            string name = Request.Form.FirstOrDefault(p => p.Key == "name").Value;
            string platform = Request.Form.FirstOrDefault(p => p.Key == "platform").Value;
            string engine = Request.Form.FirstOrDefault(p => p.Key == "engine").Value;
            return "name: "+name+", platform: "+ platform+", engine: " + engine;
        }
           
            // 5) Передача данных в контроллер с помощью GET-запрса в виде набора полей
        [HttpGet]
        public string DataFromViewToControllerByGETFields(string name, string lastname)
        {
            return $"Передано методом GET в виде набора полей в контроллер: Name: {name}, Last name: {lastname}";
        }
        #endregion


#region     *************************     Depenndency injection (внедрение зависимостей)      *************************************
        // подключение на html страницу определённых сервисов, которые выводят на страницу результат своей работы
        public IActionResult DependencyInjection()
        {
            return View();              // вьюха с использованием сервиса
        }
#endregion


#region *************************     Cтраничка с созданием нового юзера    *******************************

        public IActionResult CreateUser()
        {
            ViewBag.Ages = new SelectList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 52, 26, 27, 28, 29, 30 });             // из этого списка будем выбирать возраст в представлении
            Dictionary<string, string> names = new Dictionary<string, string>() { { "имя 1", "Qwerty" }, { "имя 2", "asdfg"} };                                                     // из этого словаря будем выбирать имена в представлении
            ViewBag.Names = new SelectList(names, "Value", "Key");
            return View();     
        }

        [HttpPost]
        [ValidateAntiForgeryToken]            // позволяет предотвратить атаки с подделкой межсайтовых запросов. Токен автоматически вставляется в представление с помощью FormTagHelper и включается при отправке формы пользователем. Токен проверяется по атрибуту ValidateAntiForgeryToken
        public  User CreateUser([Bind("Name", "Age")] User user)        // будем привязывать к модели всё кроме id
        {
            if (ModelState.IsValid)
            {
                return user;
            }
            else
            {
                return new User() { Name = "ERrOR"};
            }
        }
        #endregion

    }
}
