using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;
using MeidPlus.Repository.Base;
using MeidPlus.Repository.EFRepository.Base;

namespace MeidPlus.Repository.EFRepository
{
    public abstract class EFBaseRepository<T, K> : BaseRepository, IRepository<T, K> where T : AggregateRoot<K>
    {
        private EFUnitOfWork unitOfWork;
        public EFBaseRepository(EFUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
        public virtual IQueryable<T> Entities => unitOfWork.Set<T>();

        public virtual int Delete(K id) {
            var t = GetById(id);
            if (t == null)
            {
                return 0;
            }
            return Delete(t);
        }
       
        public virtual int Delete(params T[] t) {
            unitOfWork.Set<T>().RemoveRange(t);
            return unitOfWork.Commit();
        }
        public virtual T GetById(K id) => unitOfWork.Set<T>().Find(id);
        public virtual int Insert(params T[] t) {
            unitOfWork.AddRange(t);
           return  unitOfWork.Commit();
        }
        public virtual int Update(T[] t) {
            unitOfWork.Set<T>().UpdateRange(t);
            return unitOfWork.Commit();
        }
    }
}
