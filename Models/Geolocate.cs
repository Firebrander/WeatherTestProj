using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WeatherTestProj.Models
{
    public class Geolocate
    {
        public string Namelocation;
        public Array local_names;
        public string lat; //Geographical coordinates of the found location (latitude)
        public string lon; //Geographical coordinates of the found location (longitude)
        public string country; //Country of the found location
        public string USstate; //(where available) State of the found location
    }
}