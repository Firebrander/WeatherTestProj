using Antlr.Runtime.Tree;
using Newtonsoft.Json;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WeatherTestProj.Models;
using WeatherTestProj.Services.Business;
using static System.Net.WebRequestMethods;

namespace WeatherTestProj.Controllers
{
    public class TestFetchController : Controller
    {
        // GET: TestFetch
        public ActionResult Index()
        {
            return View("TestFetch");
        }

        public async Task<ActionResult> FetchData(ReturnData ReturnData)
        {
            Current current = new Current("53383be5b27959874a8eff555b00cd4f");
            if (ReturnData.searchterms != null)
            {
                // *** code not needed as nuget or API code can determine country if separated by comma ***...
                //var ccode = "";
                //CharEnumerator ch = ReturnData.searchterms.GetEnumerator();
                //while (ch.MoveNext())
                //{
                //Console.WriteLine(ch.Current);
                //if ((ch.Current) == ',')
                //{
                //ccode = ccode + (ch.Current + 1);
                //ccode = ccode + (ch.Current + 2);
                //}
                //}
                WeatherData weatherData = await current.GetWeatherDataByCityNameAsync(ReturnData.searchterms,"");
                if (weatherData is object)
                {
                    //var tempStr = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
                    //tempStr = tempStr + " " + weatherData.Name.ToString();
                    //tempStr = tempStr + " " + weatherData.DayInfo.Country.ToString();
                    //tempStr = tempStr + " " + weatherData.WeatherDayInfo.Temperature.ToString() + "°C ";
                    //tempStr = tempStr + " Pressure " + weatherData.WeatherDayInfo.Pressure.ToString() + " mb ";
                    //tempStr = tempStr + " Min. Temp. " + weatherData.WeatherDayInfo.MinimumTemperature.ToString() + "°C ";
                    //tempStr = tempStr + " Max. Temp. " + weatherData.WeatherDayInfo.MaximumTemperature.ToString() + "°C ";
                    //tempStr = tempStr + " Humidity " + weatherData.WeatherDayInfo.Humidity.ToString() + "% ";
                    //tempStr = tempStr + " Sunrise  " + weatherData.DayInfo.Sunrise.ToString("hh:mm tt") + " ";
                    //tempStr = tempStr + " Sunset " + weatherData.DayInfo.Sunset.ToString("hh:mm tt") + " ";
                    //tempStr = tempStr + " ID " + weatherData.Weathers[0].Id.ToString() + " ";
                    //tempStr = tempStr + " Main " + weatherData.Weathers[0].Main.ToString() + " ";
                    //tempStr = tempStr + " Description " + weatherData.Weathers[0].Description.ToString() + " ";
                    //tempStr = tempStr + " Icon " + weatherData.Weathers[0].Icon.ToString() + " ";
                    //ViewBag.message = tempStr;
                    ReturnData.Placename = weatherData.Name.ToString();
                    ReturnData.Country = weatherData.DayInfo.Country.ToString();
                    ReturnData.Today = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
                    ReturnData.Icon = "http://openweathermap.org/img/wn/" + weatherData.Weathers[0].Icon.ToString() +".png";
                    ReturnData.Temp = weatherData.WeatherDayInfo.Temperature.ToString();
                    ReturnData.Description = weatherData.Weathers[0].Description.ToString();
                    ReturnData.Mintemp = weatherData.WeatherDayInfo.MinimumTemperature.ToString();
                    ReturnData.Maxtemp = weatherData.WeatherDayInfo.MaximumTemperature.ToString();
                    ReturnData.Pressure = weatherData.WeatherDayInfo.Pressure.ToString();
                    ReturnData.Humidity = weatherData.WeatherDayInfo.Humidity.ToString();
                    ReturnData.Sunrise = weatherData.DayInfo.Sunrise.ToString("hh:mm tt");
                    ReturnData.Sunset = weatherData.DayInfo.Sunset.ToString("hh:mm tt");
                }
                else { ViewBag.message = ReturnData.searchterms + " is unknown, or weather service is down... Please try again!"; }
            }
            else { ViewBag.message = "Please enter a place to search!"; }
            return View("TestFetch",ReturnData);
        }

        private async Task <string> CallAPI()
        {
            // *** Code left here as evidence of investigation into direct calling of API rather than utilising Nuget library ***
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