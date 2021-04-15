using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectFinal.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCurrencyCalculator()
        {
            var client = new HttpClient();

            var xmlResult = client.GetStringAsync("https://cbar.az/currencies/21.10.2020.xml").Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);

            string jsonString = JsonConvert.SerializeXmlNode(doc);

            return Content(jsonString);
        }
    }
}