using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiASP.DB_Advokates;
using WebApiASP.Inputs;
using WebApiASP.Outputs;
using Newtonsoft.Json;
using System.Data.SqlClient;



namespace WebApiASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvokatesController : ControllerBase
    {
        private readonly AdvokatesContext _context;
        public AdvokatesController(AdvokatesContext context)
        {
            _context = context;
        }

        [HttpPost("getAdvokatesList")]       // обращение к этому метод API:  http://localhost:5549/api/Advoates/getAdvokatesList       метод для проекта из папки ...\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS
        public IActionResult GetAdvokatesList()
        {
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string query = "EXEC [GetAdvokatesListWitoutAuth]";
            var list = _context.Advokates.FromSql(query).ToList();


            return Ok(list);
        }

        [HttpPost("addAdvokate")]                                                  //       метод для проекта из папки ...\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS
        public Resultresponse AddAdvokate([FromBody] CAdvokate value)
        {

            if (string.IsNullOrEmpty(value.Name))
            {
                return new Resultresponse("Введите имя");
            }
            if (value.Age == 0 || value.Age == null)
            {
                return new Resultresponse("Введите возраст");
            }
            try
            {
                string query = $"EXEC [AddAdvokate] @name=N'{value.Name}', @age={value.Age}";
                int returnValue = _context.Database.ExecuteSqlCommand(query);//.Advokates.FromSql(query);

                return new Resultresponse("OK");
            }
            catch (Exception ex)
            {
                return new Resultresponse(ex.Message);
            }
        }



        [HttpPost("getAdvokatesListWithToken")]
        public GetAdvokatesList GetAdvokatesListWithToken([FromBody] CBaseAuth Auth)
        {
            GetAdvokatesList list = new GetAdvokatesList();
            try
            {

                var company = _context.Companies.FirstOrDefault(c => c.Token == Auth.Token);
                if (company == null)
                {
                    list.Status = ResultBase.statusBad;
                    list.ErrorMessage = "Wrong Token";
                    return list;
                }
                string query = $"EXEC [GetAdvokatesList] @token={Auth.Token}";
                List<WebApiASP.Outputs.Advokate> advokatesList = _context.AdvokatesList.FromSql(query).ToList();

                list.аdvokatesList = advokatesList;
                list.Status = ResultBase.statusOk;
                return list;
            }
            catch (Exception ex)
            {
                list.Status = ResultBase.statusBad;
                list.ErrorMessage = ex.Message;
                return list;
            }

        }

            // запрос к хранимой процедуры с параметрами, возвращающей таблицу, возвращаемое значение и код возврата
        [HttpPost("getFromStoredProc")]
        public void GetFromStoredProc()
        {
            int id = 1;
            string searchName = "Василий";
            SqlParameter[] @params =
                {
                    new SqlParameter("@returnVal","") {Direction = System.Data.ParameterDirection.Output},                 // код возврата, только INT
                    new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 50) {Direction = System.Data.ParameterDirection.Output},      //выходной параметр
                    new SqlParameter("@id", id) {Direction = System.Data.ParameterDirection.Input},                         // входной параметр
                    new SqlParameter("@searchName", searchName) { Direction = System.Data.ParameterDirection.Input },       // входной параметр
                };

            string query = $"EXEC @returnVal = [prGetAdvokateNameById] @id, @searchName, @name OUTPUT";

            //_context.Database.ExecuteSqlCommand(query, @params);      // не получаем выходной результирующий набор

            List<WebApiASP.Outputs.Advokate> advokatesList = _context.AdvokatesList.FromSql(query, @params).ToList();       // получаем выходной результиующий набор

            var returnVal = @params[0].Value;
            var name = @params[1].Value;
        }

        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile[] uploadedFile)
        {
            var r = Request.Form["userId"];
            foreach (IFormFile image in uploadedFile)
            {
                string path = "/Files/" + image.FileName;
                FileStream fStreem = new FileStream(path, FileMode.Create);
                image.CopyTo(fStreem);
                fStreem.Close();
            }

        }


        [HttpPost("getMultipart")]
        public void GetMultipart(string userId)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var r = Request.Form["userId"];

        }


        [HttpPost("getCasesList")]
        public GetCasesListResult GetCasesList([FromBody] CBaseAuth Auth)
        {
            GetCasesListResult result = new GetCasesListResult();
            try
            {
                var company = _context.Companies.SingleOrDefault(c => c.Token == Auth.Token);
                if (company == null)
                {
                    result.Status = ResultBase.statusBad;
                    result.ErrorMessage = "Wrong Token";
                    return result;
                }
                string query = $"EXEC [GetCasesList] @token={Auth.Token}";
                List<WebApiASP.Outputs.Case> casesList = _context.CasesList.FromSql(query).ToList();
                result.caseList = casesList;
                result.Status = ResultBase.statusOk;

                return result;
            }
            catch (Exception ex)
            {
                result.Status = ResultBase.statusBad;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        [HttpPost("getCase")]
        public GetCaseResult GetCase([FromBody] CGetCaseById input)
        {
            GetCaseResult result = new GetCaseResult();
            try
            {
                var company = _context.Companies.SingleOrDefault(c => c.Token == input.Token);
                if (company == null)
                {
                    result.Status = ResultBase.statusBad;
                    result.ErrorMessage = "Wrong Token";
                    return result;
                }
                DB_Advokates.Case caseResult = _context.Cases
                                                .Include("Advokate")
                                                //.Include("Notes")
                                                .FirstOrDefault(c => c.Id == input.Id);

                List<DB_Advokates.Note> notesResult = _context.Notes.Where(n => n.Case == caseResult).ToList();
                result.Case = caseResult;
                //result.Case.Notes = notesResult;
                result.Status = ResultBase.statusOk;
               // string res =  Newtonsoft.Json.JsonConvert.SerializeObject(result);
                
                return result;

            }
            catch (Exception ex)
            {
                result.Status = ResultBase.statusBad;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


    }






    public class Resultresponse
    {
        public Resultresponse(string status)
        {
            Status = status;
        }
        public string Status { get; set; }
    }
}