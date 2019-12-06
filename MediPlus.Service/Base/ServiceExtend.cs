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
//using MeidPlus.Repository.MongoRepository;
using MeidPlus.Repository.EFRepository.Context;
using System.IO;
using MediPlus.Domain.IRepositories.BaseRepository;
using MeidPlus.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using System.ComponentModel.Design;

namespace MediPlus.Service.Base
{
   public static class MediPlusServiceCollectionExtend
    {
        public static void ServiceInit(this IServiceCollection services) {
            services.AddAutoMapper(typeof(MapperProfile));
        }
        public static void ServiceInit(this ContainerBuilder builder)
        {           
            string codebase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            string urlpath = Uri.UnescapeDataString(uri.Path);
            var path = Path.GetDirectoryName(urlpath);
            var service = Assembly.LoadFrom($"{path}\\MediPlus.Service.dll");
            var domain = Assembly.LoadFrom($"{path}\\MediPlus.Domain.dll");
            var repository = Assembly.LoadFrom($"{path}\\MeidPlus.Repository.dll");
            var servertypes = service.GetTypes();
            var pli = new List<Type>();
            foreach (var item in servertypes.Where(a => !a.IsAbstract && a.BaseType?.BaseType == typeof(BaseTag)))
            {
                var inter = servertypes.SingleOrDefault(a => a.IsInterface && a.IsAssignableFrom(item));
                if (inter != null)
                {
                    //services.AddTransient(inter,item);
                    builder.RegisterType(item).As(inter).EnableInterfaceInterceptors();
                }
                pli.Add(item);
            }
            //services.AddAutoMapper(pli.ToArray());
            var domaintypes = domain.GetTypes().Where(a => a.IsInterface);
            foreach (var item in repository.GetTypes().Where(a => !a.IsAbstract && (typeof(IUnitOfWork).IsAssignableFrom(a) || typeof(BaseRepository).IsAssignableFrom(a))))
            {
                if (typeof(IUnitOfWork).IsAssignableFrom(item))
                {
                    //services.AddTransient(item);
                    builder.RegisterType(item);
                }
                else
                {
                    var inter = domaintypes.SingleOrDefault(a => a.IsAssignableFrom(item));
                    if (inter != null)
                    {
                        //services.AddTransient(inter, item);
                        builder.RegisterType(item).As(inter).EnableInterfaceInterceptors();
                    }
                }
            }
                                  
        }
        

        public static void UseStaticProvider(this IApplicationBuilder app) {
            ServiceLocator.Provider = app.ApplicationServices;
        }
    }

    
}
