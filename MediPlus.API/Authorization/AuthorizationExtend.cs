using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MediPlus.API
{
    public static class AuthorizationExtend
    {
        public static void AddJwt(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, IConfiguration configuration = null)
        {
            JwtSettings jwtSettings = configuration?.GetSection("JwtSettings")?.Get<JwtSettings>() ?? new JwtSettings();
            AuthorizationManager.JwtSettings = jwtSettings;
            services
           .AddAuthorization(options =>
           {
               options.AddPolicy("default", policy => policy.AddRequirements(new MediPlusRequirement()));
           })
           .AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(o =>
           {
               o.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   NameClaimType = "name",
                   RoleClaimType = "role",
                   ValidIssuer = jwtSettings.Issuer,
                   ValidAudience = jwtSettings.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
               };
           });
            services.AddSingleton<IAuthorizationHandler, MediPlusAuthorizationhandler>();
        }
    }
}
