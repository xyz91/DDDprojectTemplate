using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
   public interface IUnionOfWork
    {
         void RegisAdd<T, K>(T t) where T : AggregateRoot<K>;
         void RegisUpdate<T, K>(T t) where T : AggregateRoot<K>;
         void RegisDelete<T, K>(T t) where T : AggregateRoot<K>;
    }
}
