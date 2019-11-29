using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MediPlus.Service;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Newtonsoft.Json.Serialization;
using MediPlus.Service.Base;
using MediPlus.API.Filters;

namespace MediPlus.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ServiceInit();
            services.AddControllers(option=> {
                option.Filters.Add<ExceptionFilter>();
                option.Filters.Add<ResultFilter>();
            }).AddNewtonsoftJson(option=> {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
                option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            //services.AddDbContextPool<MediPlusContext>(option => {
            //    option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("con"));
            //});
            //services.AddDbContextPool<MediPlus2Context>(option => {
            //    option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("con2"));
            //});

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticProvider();
        }
    }
}
