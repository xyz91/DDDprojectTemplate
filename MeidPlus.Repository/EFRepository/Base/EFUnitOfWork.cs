using Autofac;
using MediPlus.Domain.Event;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;
using MediPlus.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeidPlus.Repository.EFRepository.Base
{
    public abstract class EFUnitOfWork : DbContext, IUnitOfWork, IUnionOfWork
    {
        protected abstract string Constr { get; }
        protected IConfiguration Configuration { get; }

        public static readonly ILoggerFactory Logger
     = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected EFUnitOfWork(IConfiguration configuration) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString(Constr));
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.UseLoggerFactory(Logger);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.ConfigureWarnings(warn => warn.Log(CoreEventId.DetachedLazyLoadingWarning));
        }
        public bool IsCommitted { get; set; }

        public int Commit()
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Obj>> doamins = ChangeTracker.Entries<Obj>().Where(a => a.Entity.EventDatas != null && a.Entity.EventDatas.Any());
            IEnumerable<Obj> entity = doamins.Select(a => a.Entity);
            List<IEventData> events = entity.SelectMany(a => a.EventDatas).ToList();
            //DoEvent(events, EventType.BeforeSave);
            int result = SaveChanges();
            Task<int> o = SaveChangesAsync();
            try
            {
                if (result > 0 && events != null && events.Count > 0)
                {
                    DoEvent(events, EventType.AfterSave);
                    foreach (Obj item in entity)
                    {
                        item.ClearEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message},{ex.StackTrace}");
            }
            return result;
        }
        public async Task<int> CommitAsync()
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Obj>> doamins = ChangeTracker.Entries<Obj>().Where(a => a.Entity.EventDatas != null && a.Entity.EventDatas.Any());
            IEnumerable<Obj> entity = doamins.Select(a => a.Entity);
            List<IEventData> events = entity.SelectMany(a => a.EventDatas).ToList();
            int result = await SaveChangesAsync();
            if (result > 0 && events != null && events.Count > 0)
            {
       
                await Task.Run(() =>
                {
                    try
                    {     
                        DoEvent(events, EventType.AfterSave);
                        foreach (Obj item in entity)
                        {
                            item.ClearEvents();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message},{ex.StackTrace}");
                    }
                });
            }

            return result;
        }

        private void DoEvent(List<IEventData> eventDatas, EventType eventType)
        {
            //var list = eventDatas.Where(a=>a.EventType == eventType);
            foreach (IEventData item in eventDatas)
            {
                IEnumerable<IEventHandler> handlerlist = ServiceLocator.Container.ResolveNamed<IEnumerable<IEventHandler>>(item.GetType().Name);
                foreach (IEventHandler service in handlerlist)
                {
                    try
                    {
                        service.HandleEvent(item);
                    }
                    catch (Exception e)
                    {
                        service.OnError(item, e);
                    }

                }
            }
        }
        public void RollBack() { }

        public void RegisAdd<T, K>(T t) where T : AggregateRoot<K> => Set<T>().Add(t);
        public void RegisUpdate<T, K>(T t) where T : AggregateRoot<K> => Set<T>().Update(t);
        public void RegisDelete<T, K>(T t) where T : AggregateRoot<K> => Set<T>().Remove(t);
    }
}
