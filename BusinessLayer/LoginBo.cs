using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer
{
    public class LoginBo
    {
        private PassengerDao passengerDao;
        public LoginBo()
        {
            passengerDao = new PassengerDao();
        }
    }
}
