using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTestProj.Models;
using WeatherTestProj.Services.Data;

namespace WeatherTestProj.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();
        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}