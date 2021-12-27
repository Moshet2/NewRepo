using CurrencyCon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CurrencyCon.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "http://api.exchangeratesapi.io/v1/latest?access_key=050beeaad0ad5cda72460c6758d5a11e&format=1";
        string filePath = ConfigurationManager.AppSettings["FileURL"];
        string fileNames = ConfigurationManager.AppSettings["FileName"]; 

        public async Task<ActionResult> CurrencyConverter()
        { 
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Baseurl);

            HttpContent content = response.Content;
            
            string data = await content.ReadAsStringAsync();
            ListCountryMoney EmpInfos = new ListCountryMoney();
            // var EmpInfos = JsonConvert.DeserializeObject<List<CountryMoney>>(data);
            EmpInfos = JsonConvert.DeserializeObject<ListCountryMoney>(data);
             
            return View(EmpInfos); 
        }
         
        #region DownloadFile
        public ActionResult DownloadFile(int fileName)
        {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(
               // fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);  
            fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileNames);
        }
        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        #endregion

        
        public ActionResult About()
        {
            return View();
        }
    }
}