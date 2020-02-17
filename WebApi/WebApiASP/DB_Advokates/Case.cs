using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiASP.DB_Advokates
{
    public class Case
    {



        public int Id { get; set; }


        public int AdvokateId { get; set; }
        //[ForeignKey("AdvokateId")]
        public virtual Advokate Advokate { get; set; }

        public string Info { get; set; }
        public DateTime? Date { get; set; }

        public List<Note> Notes { get; set; }

        public Case()
        {
            Notes = new List<Note>();
        }
    }
}
