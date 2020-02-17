using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiASP.Outputs
{
    public class ResultBase
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }

        public static string statusOk = "ok";
        public static string statusBad = "bad";
        public static string badToken = "Доступ к данным по данному токену отсутствует";        
    }
}
