using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiASP.Outputs
{
    public class Note
    {
        public Case Case { get; set; }
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string  Text { get; set; }
        public DateTime? Date { get; set; }
    }
}
