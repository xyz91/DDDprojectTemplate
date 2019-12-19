
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
namespace MediPlus.API
{
   
    public class JwtSettings
    {
        public string Issuer { get; set; } = "mediplus";
        public string Audience { get; set; } = "mediplus";
        public string SecretKey { get; set; } = "gi29gjj&923#JFfhi#8f~#%)_GB#f8";
        public string Policy { get; set; } = "default";
        public double Expires { get; set; } = 60 * 24;
        public DateTime? NotBefore { get; set; }
    }
   


   
    
   



}
