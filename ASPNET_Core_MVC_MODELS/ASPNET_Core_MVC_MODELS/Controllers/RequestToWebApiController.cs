using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNET_Core_MVC_MODELS.ViewModels.AdvokatesViewModel;
using Newtonsoft;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace ASPNET_Core_MVC_MODELS.Controllers
{

    // Обращаться будем к ВЕБ АПИ  http://localhost:5549/api/Advoates/   проект находится тут: D:\Projects\GoogleDrive\Programming\C#\ASPNet\WebApi

    public class RequestToWebApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAdvokateList()
        {
                    // делаем запрос на веб апи по адресу http://localhost:5549/api/Advkoates/getAdvokatesList        
            string mes = "";
            try
            {
                string uri = "http://localhost:5549/api/Advokates/getAdvokatesList";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "POST";
                Stream RequestStream = req.GetRequestStream();
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                mes = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            List<Advokate> list = RestSharp.SimpleJson.DeserializeObject<List<Advokate>>(mes);
            
            return View(list);
        }
        [HttpGet]
        public IActionResult AddAdvokate()
        {

            return View();
        }

        [HttpGet("uploadFile")]
        public IActionResult UploadFile()
        {
            return View();
        }


        // метод для заливки файлов и данных на веб АПИ.   проект веб АПИ лежит по адресу D:\Projects\GoogleDrive\Programming\C#\ASPNet\WebApi
        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile[] uploadedFile, string userId)
        {
            // запись файла на диск
            //foreach (IFormFile image in uploadedFile)
            //{
            //    string path = "/Files/" + image.FileName;
            //    FileStream fStreem = new FileStream(path, FileMode.Create);
            //    image.CopyTo(fStreem);
            //    fStreem.Close();
            //}



            //var client = new RestClient("http://localhost:5549/api/Advokates/uploadFile");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "multipart/form-data");
            //request.AddFile("uploadedFile", "D:/КАРТИНЫ/ВАЛЕДЖО/ВАЛЕДЖО/100%/28.jpg");
            //request.AddFile("uploadedFile", "D:/КАРТИНЫ/ВАЛЕДЖО/ВАЛЕДЖО/100%/45.jpg");
            //request.AddFile("uploadedFile", "D:/КАРТИНЫ/ВАЛЕДЖО/ВАЛЕДЖО/100%/1680x1050.jpg");
            //request.AddParameter("userId", "66");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5549/api/Advokates/uploadFile");
            req.Method = "POST";
            string boundary = "----------------------------859725831592300610781006";   // граница для кусков multipart/form-data
            //int userId = 66;
            byte[] boundarybytes = Encoding.UTF8.GetBytes("--" + boundary + Environment.NewLine);    // The first boundary              
            byte[] trailer = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--" + Environment.NewLine);    // the last boundary.

            req.ContentType = "multipart/form-data; boundary=" + boundary;
            req.KeepAlive = true;
            //req.Accept = "*/*";
            req.Headers.Add("Cache-Control", "no-cache");
            
            using (Stream requestStream = req.GetRequestStream())
            {               
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                byte[] userIdBytes = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"userId\"" +  Environment.NewLine + Environment.NewLine + userId.ToString() );   // name - наименование куска данных
                requestStream.Write(userIdBytes, 0, userIdBytes.Length);
                boundarybytes = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + Environment.NewLine);    // The other boundary 
                foreach (IFormFile image in uploadedFile)
                {
                    requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                    byte[] fileInfoBytes = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name = \"uploadedFile\"; filename=" + image.FileName + Environment.NewLine + "Content-Type: image/jpeg" + Environment.NewLine + Environment.NewLine);
                    requestStream.Write(fileInfoBytes, 0, fileInfoBytes.Length);
                    //image.OpenReadStream().CopyTo(requestStream);
                    image.CopyTo(requestStream);
                }
                requestStream.Write(trailer, 0, trailer.Length);
                requestStream.Close();
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
            }
        }

        [HttpPost]
        public string AddAdvokate(Advokate advokate)
        {
            if (ModelState.IsValid)
                try
                {
                    string mes = "";
                    string uri = "http://localhost:5549/api/Advokates/addAdvokate";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                    req.Method = "POST";
                    req.ContentType = "application/json";
                    string message = "{\"Name\":\"" + advokate.Name + "\",\"Age\":" + advokate.Age + "\"}";
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    req.ContentLength = bytes.Length;
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    
                    requestStream.Close();

                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    Stream stream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    mes = reader.ReadToEnd();
                    return mes;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            else
                return "Not OK";
        }


    }
}