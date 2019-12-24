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
        public PageDTO<D> Search(int pageIndex,int pageSize) {
            return Map<Page<T>,PageDTO<D>>(repository.Search(pageIndex, pageSize));
        }
        public async Task<PageDTO<D>> SearchAsync(int pageIndex, int pageSize)
        {
            return Map<Page<T>, PageDTO<D>>(await repository.SearchAsync(pageIndex, pageSize));
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

        public Task<T> GetByIdAsnyc(K id) {
           return repository.GetGyIdAsync(id);
        }
        public async Task<D> GetDTOByIdAsnyc(K id) {
          return Map(await GetByIdAsnyc(id));
        }
        public Task<int> InsertAsync(T t) {
            return repository.InsertAsync(t);
        }
        public Task<int> InsertAsnyc(D d) {
            return repository.InsertAsync(Map(d));
        }
        public Task<int> DeleteAsync(K id) {
            return repository.DeleteAsync(id);
        }
        public Task<int> DeleteAsync(T t) {
            return repository.DeleteAsync(t);
        }
        public Task<int> UpdateAsync(T t) {
            return repository.UpdateAsync(t);
        }
        public Task<int> UpdateAsync(D d) {
            return repository.UpdateAsync(Map(d));
        }
    }

   
}
