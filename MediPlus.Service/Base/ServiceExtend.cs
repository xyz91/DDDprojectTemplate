using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MediPlus.Domain.IRepositories;
using MediPlus.Service.Interface;
using AutoMapper;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using System.Linq;
using System.Reflection;
using System.IO;
using MediPlus.Domain.IRepositories.BaseRepository;
using Microsoft.AspNetCore.Builder;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using System.ComponentModel.Design;
using MediPlus.Utility;
using MediPlus.Domain.Event;
using MediPlus.Domain.Service;
using MediPlus.Domain.Model.BaseModel;
using MediPlus.Domain.IRepositories.Context;
using Castle.DynamicProxy;

namespace MediPlus.Service.Base
{
   public static class MediPlusServiceCollectionExtend
    {
        public static void ServiceInit(this IServiceCollection services) {
            services.AddAutoMapper(typeof(MapperProfile));           
        }
        public static void ServiceInit(this ContainerBuilder builder)
        {
            string codebase = typeof(MediPlusServiceCollectionExtend).Assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            string urlpath = Uri.UnescapeDataString(uri.Path);
            var path = Path.GetDirectoryName(urlpath);

            var domaintypes = typeof(Obj).Assembly.GetTypes().ToList();
            var domaininterface = domaintypes.Where(a => a.IsInterface).ToList();

            
            var repository = Assembly.LoadFrom($"{path}\\MeidPlus.Repository.dll");
            var repositorytypes = repository.GetTypes().ToList();

            var servertypes = typeof(BaseService).Assembly.GetTypes();
            
            foreach (var item in servertypes.Where(a => !a.IsAbstract && a.BaseType.IsGenericType && a.BaseType.GetGenericTypeDefinition() == typeof(BaseUnitService<,,>)))
            {
                var inter = servertypes.SingleOrDefault(a => a.IsInterface && a.IsAssignableFrom(item));
                if (inter != null)
                {
                    builder.RegisterType(item).As(inter).InterceptedBy(typeof(Log)).EnableInterfaceInterceptors();
                }
            }
           
            foreach (var item in repositorytypes.Where(a => !a.IsAbstract && typeof(IUnitOfWork).IsAssignableFrom(a)))
            {
                var oowf = item.GetInterfaces();
                var oooooooo = domaininterface.Where(a =>a.Name != typeof(IMediPlusBaseContext).Name && typeof(IMediPlusBaseContext).IsAssignableFrom(a) && a.IsAssignableFrom(item));
                var inter = domaininterface.SingleOrDefault(a => a.Name != typeof(IMediPlusBaseContext).Name && typeof(IMediPlusBaseContext).IsAssignableFrom(a) && a.IsAssignableFrom(item));
                if (inter != null)
                {
                    builder.RegisterType(item).As(inter).InstancePerLifetimeScope();
                }
                   
            }
            foreach (var item in repositorytypes.Where(a=>!a.IsAbstract &&(a.BaseType?.IsGenericType??false) && a.BaseType.GetInterfaces().Any(b=>b.IsGenericType && b.GetGenericTypeDefinition() == typeof(IRepository<,>))))
            {
                var inter = domaininterface.SingleOrDefault(a => a.IsAssignableFrom(item));
                if (inter != null)
                {
                    //services.AddTransient(inter, item);
                    builder.RegisterType(item).As(inter).EnableInterfaceInterceptors();
                }
            }
            foreach (var item in domaininterface.Where(a=>a.GetInterfaces().Any(b=>b == typeof(IDomainService))))
            {
                var domainservice = domaintypes.SingleOrDefault(a=>!a.IsInterface && item.IsAssignableFrom(a));              
                if (domainservice != null)
                {
                    builder.RegisterType(domainservice).As(item).EnableInterfaceInterceptors();
                }
            }
            var eventhandlers = domaintypes.Where(a => !a.IsAbstract && (a.BaseType?.IsGenericType ?? false) && a.BaseType.GetGenericTypeDefinition() == typeof(BaseEventHandler<>));
            foreach (var item in eventhandlers)
            {
                var eventdata = item.BaseType.GetGenericArguments()[0];
                 builder.RegisterType(item).Named<IEventHandler>(eventdata.Name);
            }


            builder.RegisterType<Log>();

        }
        

        public static void UseStaticProvider(this IApplicationBuilder app) {
            ServiceLocator.Provider = app.ApplicationServices;
            ServiceLocator.Container = app.ApplicationServices.GetAutofacRoot();
        }
    }
    /// <summary>
    ///          [Intercept(typeof(Log))]
    ///          
    /// </summary>
    public class Log : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(IInvocation invocation) {
            Console.WriteLine(invocation.Method.Name +" befroe");
            invocation.Proceed();
            Console.WriteLine(invocation.Method.Name + " after");
        }
    }




}
