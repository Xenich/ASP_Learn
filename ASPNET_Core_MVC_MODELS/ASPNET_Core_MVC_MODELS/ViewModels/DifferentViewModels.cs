using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ASPNET_Core_MVC_MODELS.Models;        // ВАЖНО - подключить пространство имён с моделями

namespace ASPNET_Core_MVC_MODELS.ViewModels
{
        // класс служит для передачи коллекций элементов разных типов из контроллера в представление
    public class DifferentViewModels
    {
        public IEnumerable<Company> Companies { get; set; }     // не обязательно использовать IEnumerable, можно List или 
                                                                // другую коллекцию, которая реализует интерфейс IEnumerable
        public IEnumerable<Game> Games { get; set; }
    }
}
