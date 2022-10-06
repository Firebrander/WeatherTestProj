using Antlr.Runtime.Tree;
using Newtonsoft.Json;
using OpenWeatherMap.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherTestProj.Models;

namespace WeatherTestProj.Controllers
{
    public class TestFetchController : Controller
    {
        // GET: TestFetch
        public ActionResult Index()
        {
            return View("TestFetch");
        }

        public string Returnstr(ReturnData ReturnData)
        {
            string tempstr = "53383be5b27959874a8eff555b00cd4f";
            //Task retstring = CallAPI();
            var test = new Object();
            Current current = new Current(tempstr);
            return current.GetForecastDataByCityNameAsync("London", "UK").ToString();
            //return obj.ToString();
            //return "Current temperature is " + retstring +"°F";
        }

        private async Task <string> CallAPI()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            //var response = await client.GetAsync($"/data/2.5/weather?q=London,UK&appid=c44d8aa0c5e588db11ac6191c0bc6a60");
            HttpResponseMessage response = await client.GetAsync("http://api.openweathermap.org/geo/1.0/direct?q=London&limit=5&appid=53383be5b27959874a8eff555b00cd4f");
            response.EnsureSuccessStatusCode();
            //System.Diagnostics.Debug.WriteLine(response);

            var stringResult = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<dynamic>(stringResult);
            var tmpDegreesF = Math.Round(((float)obj.main.temp * 9 / 5 - 459.67), 2);
            //Console.WriteLine($"Current temperature is {tmpDegreesF}°F");
            //Console.ReadKey();
            //return tmpDegreesF.ToString();
            return response.ToString();
        }
    }
}