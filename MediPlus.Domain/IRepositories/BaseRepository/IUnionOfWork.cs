using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
   public interface IUnionOfWork
    {
        public void RegisAdd<T, K>(T t) where T : AggregateRoot<K>;
        public void RegisUpdate<T, K>(T t) where T : AggregateRoot<K>;
        public void RegisDelete<T, K>(T t) where T : AggregateRoot<K>;
    }
}
