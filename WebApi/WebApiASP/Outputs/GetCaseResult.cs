using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiASP.Outputs
{
    public class GetCaseResult : ResultBase
    {
        public DB_Advokates.Case Case = new DB_Advokates.Case();
    }
}
