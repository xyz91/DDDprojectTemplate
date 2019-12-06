using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
namespace MediPlus.Service
{
   public class BaseService <T,K,D>:BaseTag,IBaseService<T,K,D>  where T : AggregateRoot<K>   where D: EntityDTO<K>
    {        
        protected  IRepository<T, K> repository;
        private IMapper Mapper { get; set; }= (IMapper)ServiceLocator.Provider.GetService(typeof(IMapper));
        protected BaseService(IRepository<T, K> repository){
            this.repository = repository;              
            
        }
        public M Map<S,M>(S s) {
           return Mapper.Map<S, M>(s);
        }
        public D Map(T obj) 
        {           
            return Mapper?.Map<D>(obj);
        }
        public T Map(D obj) {
            return Mapper?.Map<T>(obj);
        }
        public T GetById(K id) {
           return repository.GetById(id);
        }
        public D GetDTOById(K id) {
            return Map(GetById(id));
        }
        public int Insert(T t) {
            return repository.Insert(t);
        }
        public int Insert(D d) {
            return Insert(Map(d));
        }
        public int Delete(K id) {
            return repository.Delete(id);
        }
        public int Delete(T t)
        {
            return repository.Delete(t.Id);
        }
        public int Update(T t) {
            return repository.Update(t);
        }
        public int Update(D d) {
            return repository.Update(Map(d));
        }
    }

    public class BaseTag 
    { 
    
    }
}
