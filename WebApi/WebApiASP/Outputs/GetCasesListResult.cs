using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiASP.Outputs
{
    public class GetCasesListResult : ResultBase
    {
        public List<Case> caseList = new List<Case>();
    }
}
