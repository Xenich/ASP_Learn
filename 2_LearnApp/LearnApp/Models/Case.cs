using System;
using System.Collections.Generic;

namespace LearnApp.Models
{
    public partial class Case
    {
        public Case()
        {
            Note = new HashSet<Note>();
        }

        public int Id { get; set; }
        public int? AdvokateId { get; set; }
        public string Info { get; set; }
        public DateTime? Date { get; set; }

        public Advokate Advokate { get; set; }
        public ICollection<Note> Note { get; set; }
    }
}
