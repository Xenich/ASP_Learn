using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // для [Display]

namespace ASPNET_Core_MVC_MODELS.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Display(Name = "Имя юзера")]               // то, что будет отображаться в формах при ссылке на эту модель
        public string Name { get; set; }
        [Display(Name = "Возраст юзера")]
        public int Age { get; set; }
    }

    public enum TimeOfDay
    {
        [Display(Name = "Утро")]
        Morning,
        [Display(Name = "День")]
        Afternoon,
        [Display(Name = "Вечер")]
        Evening,
        [Display(Name = "Ночь")]
        Night
    }
}
