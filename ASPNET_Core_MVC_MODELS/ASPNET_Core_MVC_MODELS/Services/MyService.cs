using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_MODELS.Services
{
    public class MyService
    {
        public string GreetFromService()            // в View этот сервис подключается с помощью @inject ASPNET_Core_MVC_MODELS.Services.MyService MyService
                                                    // вызывается в любом месте в View так: @MyService.GreetFromService()
                                                    // в файле startup необходимо подключить сервис: services.AddTransient<MyService>();
        {
            return "Hello from service!!. Date: " + DateTime.Now;
        }
    }
}
