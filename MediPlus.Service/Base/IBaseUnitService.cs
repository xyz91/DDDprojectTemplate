using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service
{
   public interface IBaseUnitService<T, K, D> where T : AggregateRoot<K> where D : EntityDTO<K>
    {
         M Map<S, M>(S s);
        D Map(T obj);
       
        T Map(D obj);

         T GetById(K id);
        Task<T> GetByIdAsnyc(K id);

         D GetDTOById(K id);
        Task<D> GetDTOByIdAsnyc(K id);

         int Insert(T t);
        Task<int> InsertAsync(T t);

         int Insert(D d);
        Task<int> InsertAsnyc(D d);

         int Delete(K id);
        Task<int> DeleteAsync(K id);

         int Delete(T t);
        Task<int> DeleteAsync(T t);

         int Update(T t);
        Task<int> UpdateAsync(T t);

         int Update(D d);
        Task<int> UpdateAsync(D d);
         PageDTO<D> Search(int pageIndex, int pageSize);
        Task<PageDTO<D>> SearchAsync(int pageIndex, int pageSize);

    }
}
