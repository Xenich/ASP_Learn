using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // для [Display]
using Microsoft.AspNetCore.Mvc;                     // для HiddenInput

namespace ASPNET_Core_MVC_MODELS.ViewModels.AdvokatesViewModel
{
    public class Advokate
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя адвоката")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        [Display(Name = "Возраст адвоката")]
        public int? Age { get; set; }
    }
}
