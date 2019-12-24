using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    public interface IRepository<T,K> where T : AggregateRoot<K>
    {
        IQueryable<T> Entities { get; }

        int Insert(T t);
        Task<int> InsertAsync(T t);
        int Delete(K id);
        Task<int> DeleteAsync(K id);
        int Delete(T t);
        Task<int> DeleteAsync(T t);
        int Update(T t);
        Task<int> UpdateAsync(T t);
        T GetById(K id);
        Task<T> GetGyIdAsync(K id);
         Page<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
         Page<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null);
        Task<Page<T>> SearchAsync<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
        Task<Page<T>> SearchAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null);


    }
}
