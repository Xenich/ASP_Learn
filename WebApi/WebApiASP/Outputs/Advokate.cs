using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiASP.Outputs
{
    public class Advokate
    {

        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}


