using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTestProj.Models;

namespace WeatherTestProj.Services.Data
{
    public class SecurityDAO
    {
        internal bool FindByUser(UserModel user)
        {
            return (user.username == "Admin") && (user.password == "Secret"); 
            //throw new NotImplementedException();
        }
    }
}