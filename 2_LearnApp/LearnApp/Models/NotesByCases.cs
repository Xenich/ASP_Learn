using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApp.Models
{
    public class NotesByCases
    {
        [Key]
        public int NoteId { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]
        public DateTime? NoteDate { get; set; }
        
        [Display(Name = "Информация о деле")]
        public string caseInfo { get; set; }

        [Display(Name = "Назначенный адвокат")]
        public string Advokat { get; set; }
    }
}
