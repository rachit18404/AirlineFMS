using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FMSApi.Services
{
    public class LoginService
    {
        private PassengerDao passengerDao;
        public LoginService()
        {
            passengerDao = new PassengerDao();
        }
        public Hashtable PassengerLogin(string email, string password)
        {
            try
            {
                Passenger passenger = passengerDao.PassengerLogin(email, password);
                if (passenger != null)
                {
                    var response = new Hashtable();
                    response.Add("passengerId", passenger.passengerId);
                    response.Add("token", GenerateToken(passenger));
                    response.Add("name", passenger.name);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GenerateToken(Passenger passenger)
        {

            var _config = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Email, passenger.email),
                    new Claim(ClaimTypes.Sid, passenger.passengerId.ToString())
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }
}
