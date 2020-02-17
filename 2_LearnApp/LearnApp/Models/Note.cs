using System;
using System.Collections.Generic;

namespace LearnApp.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public DateTime? Date { get; set; }

        public Case Case { get; set; }
    }
}
