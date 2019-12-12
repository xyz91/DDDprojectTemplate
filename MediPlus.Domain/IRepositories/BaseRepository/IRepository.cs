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
        IQueryable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> expression, int pageIndex = 1, int pageSize = 10);
        void Load<P>(T t, Expression<Func<T, IEnumerable<P>>> expression) where P : class;
        void Load<P>(T t, Expression<Func<T, P>> expression) where P : class;

    }
}
