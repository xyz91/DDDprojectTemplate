using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MediPlus.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Utility;
using MediPlus.Domain.Model;
using System.Linq;
using MediPlus.Domain.Event;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using MediPlus.Domain.Model.BaseModel;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MeidPlus.Repository.EFRepository.Base
{
    public abstract class EFUnitOfWork : DbContext, IUnitOfWork,IUnionOfWork
    {
        protected abstract string Constr { get; }
        protected IConfiguration Configuration { get; }

        public static readonly ILoggerFactory Logger
     = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected EFUnitOfWork(IConfiguration configuration)
        {
            this.Configuration = configuration; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString(Constr));
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.UseLoggerFactory(Logger);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.ConfigureWarnings(warn => warn.Log(CoreEventId.DetachedLazyLoadingWarning));
        }
        public bool IsCommitted { get; set; }

        public int Commit()
        {
            var doamins = this.ChangeTracker.Entries<Obj>().Where(a => a.Entity.EventDatas != null && a.Entity.EventDatas.Any());
            var events = doamins.SelectMany(a => a.Entity.EventDatas).ToList();            
            //DoEvent(events, EventType.BeforeSave);
            var result = this.SaveChanges();
            if (result > 0)
            {              
                DoEvent(events, EventType.AfterSave);
            }            
            return result;
        }

        private void DoEvent(List<IEventData> eventDatas, EventType eventType)
        {
            //var list = eventDatas.Where(a=>a.EventType == eventType);
            foreach (var item in eventDatas)
            {
                var handlerlist = ServiceLocator.Container.ResolveNamed<IEnumerable<IEventHandler>>(item.GetType().Name);
                foreach (var service in handlerlist)
                {
                    service.HandleEvent(item);
                }
            }
        }
        public void RollBack() { }

        public void RegisAdd<T, K>(T t) where T : AggregateRoot<K> => this.Set<T>().Add(t);
        public void RegisUpdate<T, K>(T t) where T : AggregateRoot<K> =>this.Set<T>().Update(t); 
        public void RegisDelete<T, K>(T t) where T : AggregateRoot<K> => this.Set<T>().Remove(t); 
    }
}
