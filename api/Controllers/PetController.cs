using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ui.Controllers
{
    public class PetsController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        private static string GetPet()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://api:80/api/pet").Result;
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                JObject s = JObject.Parse(result);
                string url = (string)s["url"];
                return url;
            } else
            {
                return "Fail";
            }
        }

        [Route("/pet")]
        public IActionResult Pet()
        {
            string hostname = Dns.GetHostName();
            string url = GetPet();
            ViewData["url"] = url;
            ViewData["hostname"] = hostname;
            return View();
        }
    }
}
