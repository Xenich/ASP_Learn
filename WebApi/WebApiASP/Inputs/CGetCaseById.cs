using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiASP.Inputs
{
    public class CGetCaseById : CBaseAuth
    {
        public int Id { get; set; }
    }
}
