using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Utility;

namespace MediPlus.Service
{
   public abstract class BaseUnitService <T,K,D>: BaseService, IBaseUnitService<T,K,D>  where T : AggregateRoot<K>   where D: EntityDTO<K>
    {        
        protected  IRepository<T, K> repository;
        private IMapper Mapper { get; set; }= (IMapper)ServiceLocator.Provider.GetService(typeof(IMapper));
        protected BaseUnitService(IRepository<T, K> repository){
            this.repository = repository;
        }
        public PagingDTO<D> Search(int pageIndex,int pageSize) {
            return Map<PagingObject<T>,PagingDTO<D>>(repository.Search(pageIndex, pageSize));
        }
        public async Task<PagingDTO<D>> SearchAsync(int pageIndex, int pageSize)
        {
            return Map<PagingObject<T>, PagingDTO<D>>(await repository.SearchAsync(pageIndex, pageSize));
        }
        public M Map<S,M>(S s) {
           return Mapper.Map<S, M>(s);
        }
        public D Map(T obj) 
        {           
            return Mapper?.Map<D>(obj);
        }
        public M Map<M>(M source,M dest) {
            return Mapper.Map(source,dest);
        }
        public T Map(D obj) {
            return Mapper?.Map<T>(obj);
        }
        public virtual T GetById(K id) {
           return repository.GetById(id);
        }
        public virtual D GetDTOById(K id) {
            return Map(GetById(id));
        }
        public virtual int Insert(T t) {            
            return repository.Insert(t);
        }
        public virtual int Insert(D d) {
            return Insert(Map(d));
        }
        public virtual int Delete(K id) {
            return repository.Delete(id);
        }
        public virtual int Delete(T t)
        {
            return repository.Delete(t.Id);
        }
        public virtual int Update(T t) {           
            return repository.Update(t);
        }
        public virtual int Update(D d) {
            return repository.Update(Map(d));
        }

        public virtual Task<T> GetByIdAsnyc(K id) {
           return repository.GetGyIdAsync(id);
        }
        public virtual async Task<D> GetDTOByIdAsnyc(K id) {
          return Map(await GetByIdAsnyc(id));
        }
        public virtual Task<int> InsertAsync(T t) {
            return repository.InsertAsync(t);
        }
        public virtual Task<int> InsertAsnyc(D d) {
            return repository.InsertAsync(Map(d));
        }
        public virtual Task<int> DeleteAsync(K id) {
            return repository.DeleteAsync(id);
        }
        public virtual Task<int> DeleteAsync(T t) {
            return repository.DeleteAsync(t);
        }
        public virtual Task<int> UpdateAsync(T t) {
            return repository.UpdateAsync(t);
        }
        public virtual Task<int> UpdateAsync(D d) {
            return repository.UpdateAsync(Map(d));
        }
    }

   
}
