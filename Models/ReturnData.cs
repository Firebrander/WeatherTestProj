using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTestProj.Models
{
    public class ReturnData
    {
        public string searchterms { get; set; }
        public string result { get; set; }
        public string Today { get; set; }
        public string Placename { get; set; }
        public string Country { get; set; }
        public string Temp { get; set; }
        public string Mintemp { get; set; }
        public string Maxtemp { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }  
        public string Main { get; set; }
        public string Description { get; set;}
        public string Icon { get; set; }
    }
}