using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnApp.Models
{
    public partial class Advokate
    {
        public Advokate()
        {
            Case = new HashSet<Case>();
        }

        public int Id { get; set; }
        [Display(Name = "Имя адвоката")]
        public string Name { get; set; }

        public ICollection<Case> Case { get; set; }
    }
}
