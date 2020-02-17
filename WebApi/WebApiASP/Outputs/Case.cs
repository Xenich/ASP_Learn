using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiASP.Outputs
{
    public class Case
    {
        public int AdvokateId { get; set; }
        public string AdvokateName { get; set; }
        public int? AdvokateAge { get; set; }

        public int CaseId { get; set; }
        public string CaseInfo { get; set; }
        [Column("CaseDate")]
        public DateTime? CaseDate { get; set; }

        public List<Note> Notes = new List<Note>();
    }
}
