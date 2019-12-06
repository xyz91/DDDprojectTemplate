using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    public interface IRepository<T,K> where T : AggregateRoot<K>
    {
        IQueryable<T> Entities { get; }

        int Insert(params T[] t);
        int Delete(K id);
        int Delete(params T[] t);
        int Update(params T[] t);
        T GetById(K id);

        void Load<P>(T t, Expression<Func<T, IEnumerable<P>>> expression) where P : class;
        void Load<P>(T t, Expression<Func<T, P>> expression) where P : class;

    }
}
