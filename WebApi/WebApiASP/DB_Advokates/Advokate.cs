using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiASP.DB_Advokates
{
    public class Advokate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int CompanyId { get; set; }

        public virtual List<Case> Cases { get; set; }

        public Advokate()
        {
            Cases = new List<Case>();
        }
    }
}
