using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_MODELS.Models
{
    /// <summary>
    /// Класс для отображения спска юзеров с пагинацией
    /// </summary>
    public class UserIndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
