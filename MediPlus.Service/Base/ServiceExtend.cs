using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using MediPlus.Domain.Event;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model.BaseModel;
using MediPlus.Domain.Service;
using MediPlus.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MediPlus.Service.Base
{
    public static class MediPlusServiceCollectionExtend
    {
        /// <summary>
        /// service扩展
        /// </summary>
        /// <param name="services"></param>
        public static void ServiceInit(this IServiceCollection services) {

            services.AddAutoMapper(typeof(MapperProfile));
        }
        /// <summary>
        /// autofac扩展
        /// </summary>
        /// <param name="builder"></param>
        public static void ServiceInit(this ContainerBuilder builder)
        {
            string codebase = typeof(MediPlusServiceCollectionExtend).Assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            string urlpath = Uri.UnescapeDataString(uri.Path);
            string path = Path.GetDirectoryName(urlpath);

            List<Type> domaintypes = typeof(Obj).Assembly.GetTypes().ToList();
            List<Type> domaininterface = domaintypes.Where(a => a.IsInterface).ToList();


            Assembly repository = Assembly.LoadFrom($"{path}\\MeidPlus.Repository.dll");
            List<Type> repositorytypes = repository.GetTypes().ToList();

            Type[] servertypes = typeof(BaseService).Assembly.GetTypes();

            //foreach (var item in servertypes.Where(a => !a.IsAbstract && a.BaseType.IsGenericType && a.BaseType.GetGenericTypeDefinition() == typeof(BaseUnitService<,,>)))
            foreach (Type item in servertypes.Where(a => !a.IsAbstract && (a.BaseType == typeof(BaseService) || a.BaseType?.BaseType == typeof(BaseService))))
            {
                Type inter = servertypes.SingleOrDefault(a => a.IsInterface && a.IsAssignableFrom(item));
                if (inter != null)
                {
                    builder.RegisterType(item).As(inter).InterceptedBy(typeof(Log)).EnableInterfaceInterceptors();
                }
            }

            foreach (Type item in repositorytypes.Where(a => !a.IsAbstract && typeof(IUnitOfWork).IsAssignableFrom(a)))
            {
                //Type inter = domaininterface.SingleOrDefault(a => a != typeof(IMediPlusBaseContext) && typeof(IMediPlusBaseContext).IsAssignableFrom(a) && a.IsAssignableFrom(item));
                //if (inter != null)
                //{
                //    builder.RegisterType(item).As(inter).InstancePerLifetimeScope();
                //}
                builder.RegisterType(item).InstancePerLifetimeScope();
            }
            
             foreach (var item in repositorytypes.Where(a=>!a.IsAbstract &&(a.BaseType?.IsGenericType??false) && a.BaseType.GetInterfaces().Any(b=>b.IsGenericType && b.GetGenericTypeDefinition() == typeof(IRepository<,>))))         
            {
                Type inter = domaininterface.SingleOrDefault(a => a.IsAssignableFrom(item));
                if (inter != null)
                {
                    //services.AddTransient(inter, item);
                    builder.RegisterType(item).As(inter).EnableInterfaceInterceptors().InstancePerLifetimeScope();
                }
            }
            foreach (var item in repositorytypes.Where(a=>!a.IsAbstract && a.GetInterfaces().Any(b=>b == typeof(IRedisRepository))))
            {
                Type inter = domaininterface.SingleOrDefault(a => a.IsAssignableFrom(item) && a != typeof(IRedisRepository));
                if (inter != null)
                {
                    builder.RegisterType(item).As(inter).EnableInterfaceInterceptors();
                }
            }
            foreach (Type item in domaininterface.Where(a => a.GetInterfaces().Any(b => b == typeof(IDomainService))))
            {
                Type domainservice = domaintypes.SingleOrDefault(a => !a.IsInterface && item.IsAssignableFrom(a));
                if (domainservice != null)
                {
                    builder.RegisterType(domainservice).As(item).EnableInterfaceInterceptors();
                }
            }
            IEnumerable<Type> eventhandlers =domaintypes.Concat(servertypes).Where(a => !a.IsAbstract && (a.BaseType?.IsGenericType ?? false) && a.BaseType.GetGenericTypeDefinition() == typeof(BaseEventHandler<>));
            foreach (Type item in eventhandlers)
            {
                Type eventdata = item.BaseType.GetGenericArguments()[0];
                builder.RegisterType(item).Named<IEventHandler>(eventdata.Name);
            }


            builder.RegisterType<Log>();
        }

        /// <summary>
        /// app 扩展
        /// </summary>
        /// <param name="app"></param>
        public static void UseStaticProvider(this IApplicationBuilder app)
        {
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
        /// <summary>
        /// aop
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + " befroe");
            invocation.Proceed();
            Console.WriteLine(invocation.Method.Name + " after");
        }
    }

}
