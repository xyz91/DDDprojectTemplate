using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MediPlus.Domain.Event;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;
using MediPlus.Utility;
using MeidPlus.Repository.MongoRepository.Mapping;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Base
{
    public abstract class MongoUnitOfWork : MongoBaseContext, IUnitOfWork, IUnionOfWork
    {
        private MongoClient _client = null;
        private IClientSessionHandle _sessionHandle = null;
        private object _lock = new object();
        private List<Obj> changeObj = new List<Obj>();
        private IClientSessionHandle SessionHandle {
            get {
                if (_sessionHandle == null)
                {
                    lock (_lock) {
                        if (_sessionHandle == null)
                        {
                            var session = _client.StartSession();
                            session.StartTransaction();
                        }
                    }
                }
                return _sessionHandle;
            }
        }
        public bool IsCommitted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected MongoUnitOfWork(IConfiguration configuration, ref MongoClient client) : base(configuration, ref client) {
            _client = client;
        }

        public int Commit() {
            try
            {
                SessionHandle.CommitTransaction();
                DoEvent(changeObj.ToArray());
                return 1;
            }
            catch
            {
                return 0;
            }
            finally {
                SessionHandle.Dispose();
                _sessionHandle = null;
            }
        }
        public void RollBack() {
            try {
                SessionHandle.AbortTransaction();
            } catch( Exception ex) {
                throw ex;
            }
            finally
            {
                SessionHandle.Dispose();
                _sessionHandle = null;
            }

        }
        public void DoEvent(params Obj[] objs)
        {
            //var list = eventDatas.Where(a=>a.EventType == eventType);
            foreach (Obj obj in objs)
            {
                if (obj.EventDatas?.Count > 0)
                {
                    foreach (var item in obj.EventDatas)
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
                                try {
                                    service.OnError(item, e);
                                } catch {}
                            }

                        }
                    }
                    obj.ClearEvents();
                }               
            }
        }
        public async Task<int> CommitAsync() {
            try
            {
              await  SessionHandle.CommitTransactionAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SessionHandle.Dispose();
                _sessionHandle = null;
            }
        }
        public void RegisAdd<T, K>(T t) where T : AggregateRoot<K> {
            Database.GetCollection<T>(typeof(T).Name).InsertOne(SessionHandle, t);
            changeObj.Add(t);
        }
        public void RegisUpdate<T, K>(T t) where T : AggregateRoot<K> {
            Database.GetCollection<T>(typeof(T).Name).ReplaceOne(SessionHandle, Builders<T>.Filter.Eq(a => a.Id, t.Id), t, new UpdateOptions() { IsUpsert = true });
            changeObj.Add(t);
        }
        public void RegisDelete<T, K>(T t) where T : AggregateRoot<K> {
            Database.GetCollection<T>(typeof(T).Name).DeleteOne(SessionHandle, Builders<T>.Filter.Eq(a => a.Id, t.Id));
            changeObj.Add(t);
        }

        static MongoUnitOfWork() {
            MongodbMapping.Register();
        }

    }
}
