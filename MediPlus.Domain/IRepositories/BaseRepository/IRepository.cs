using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    public interface IRepository<T,K> where T : AggregateRoot<K>
    {
        IQueryable<T> Entities { get; }

        int Insert(T t);
        int Delete(K id);
        int Delete(T t);
        int Update(T t);
        T GetById(K id);
        public PageModel<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
        public PageModel<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null);
       

    }
}
