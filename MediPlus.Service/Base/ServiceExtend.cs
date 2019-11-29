using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MediPlus.Domain.IRepositories;
using MeidPlus.Repository;
using MediPlus.Service.Interface;
using MeidPlus.Repository.EFRepository;
using AutoMapper;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using System.Linq;
using System.Reflection;
using MeidPlus.Repository.MongoRepository;
using MeidPlus.Repository.EFRepository.Context;
using System.IO;
using MediPlus.Domain.IRepositories.BaseRepository;
using MeidPlus.Repository.Base;
using Microsoft.AspNetCore.Builder;
namespace MediPlus.Service.Base
{
   public static class MediPlusServiceCollectionExtend
    {
        public static IServiceCollection ServiceInit(this IServiceCollection services) {
            services.AddAutoMapper(typeof(MapperProfile));
            string codebase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            string urlpath = Uri.UnescapeDataString(uri.Path);
            var path = Path.GetDirectoryName(urlpath);
            var service = Assembly.LoadFrom($"{path}\\MediPlus.Service.dll");
            var domain = Assembly.LoadFrom($"{path}\\MediPlus.Domain.dll");
            var repository = Assembly.LoadFrom($"{path}\\MeidPlus.Repository.dll");
            var servertypes = service.GetTypes();
            foreach (var item in servertypes.Where(a=>!a.IsAbstract && a.BaseType == typeof(BaseService)))
            {
                var inter = servertypes.SingleOrDefault(a=>a.IsInterface && a.IsAssignableFrom(item));
                if (inter != null)
                {
                    services.AddTransient(inter,item);
                }
            }
            var domaintypes = domain.GetTypes().Where(a=>a.IsInterface);
            foreach (var item in repository.GetTypes().Where(a=>!a.IsAbstract && (typeof(IUnitOfWork).IsAssignableFrom(a) || typeof(BaseRepository).IsAssignableFrom(a))))
            {
                if (typeof(IUnitOfWork).IsAssignableFrom(item))
                {
                    services.AddTransient(item);
                }
                else {
                    var inter = domaintypes.SingleOrDefault(a => a.IsAssignableFrom(item));
                    if (inter != null)
                    {
                        services.AddTransient(inter, item);
                    }
                }    
            }
            return services;
            //return services
            //      .AddTransient(typeof(IUserService), typeof(UserService))
            //      .AddTransient(typeof(IUserRepository), typeof(UserRepository))
            //      .AddTransient(typeof(IBizOrderRepository), typeof(BizOrderRepository))
            //      .AddTransient(typeof(IBizOrderService), typeof(BizOrderService))
            //      .AddTransient(typeof(IMDBHolidayRepository),typeof(MDBHolidayRepository))
            //      .AddTransient(typeof(MeidPlus.Repository.MongoRepository.Context.MediplusContext))
            //      .AddTransient(typeof(MeidPlus.Repository.EFRepository.Context.MediPlusContext))
            //      .AddTransient(typeof(MediPlus2Context))
            //      ;                        
        }
        public static void UseStaticProvider(this IApplicationBuilder app) {
            ServiceLocator.Provider = app.ApplicationServices;
        }
    }

    
}
