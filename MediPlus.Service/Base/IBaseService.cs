using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service
{
   public interface IBaseService<T, K, D> where T : AggregateRoot<K> where D : EntityDTO<K>
    {
        public M Map<S, M>(S s);
       public D Map(T obj);
       
      public  T Map(D obj);

        public T GetById(K id);

        public D GetDTOById(K id);

        public int Insert(T t);

        public int Insert(D d);

        public int Delete(K id);

        public int Delete(T t);

        public int Update(T t);

        public int Update(D d);
       
    }
}
