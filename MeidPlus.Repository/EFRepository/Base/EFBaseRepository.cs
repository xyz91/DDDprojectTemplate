using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.IRepositories.Context;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;
using MeidPlus.Repository.Base;
using MeidPlus.Repository.EFRepository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace MeidPlus.Repository.EFRepository
{
    public abstract class EFBaseRepository<T, K>: IRepository<T, K>, IEFRepository<T, K> where T : AggregateRoot<K>
    {
        private EFUnitOfWork unitOfWork;
        public EFBaseRepository(IEFBaseContext unitOfWork) {
            this.unitOfWork = unitOfWork as EFUnitOfWork;
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
        public PageModel<T> Search<P>(int pageIndex , int pageSize , Expression<Func<T, bool>> where=null, Expression<Func<T, P>> orderby=null, bool desc = true)
        {            
            PageModel<T> page = new PageModel<T>() { PageIndex = pageIndex, PageSize = pageSize};
            where = where ?? (t => true);
            page.DataCount =  Entities.Count(where);              
            var query = Entities.AsNoTracking().Where(where);
            if (orderby != null)
            {
                query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
            }
            page.List = query.Skip(page.PageSize * (page.PageIndex - 1)).Take(pageSize).ToList();
            return page;
        }
        public PageModel<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null) {
            return Search<K>(pageIndex, pageSize, where,a=>a.Id,true);
        }
        public virtual void Load<P>(T t, Expression<Func<T, IEnumerable<P>>> expression) where P:class
        {
            unitOfWork.Entry(t).Collection<P>(expression).Load();
        }
        public virtual void Load<P>(T t, Expression<Func<T, P>> expression) where P:class{
            unitOfWork.Entry(t).Reference(expression).Load();
        }

        public virtual int Delete(T t ) {
            unitOfWork.Set<T>().Remove(t);
            return unitOfWork.Commit();
        }
        public virtual T GetById(K id) => unitOfWork.Set<T>().Find(id);
        public virtual int Insert(T t) {
            unitOfWork.Set<T>().AddRange(t);      
           return  unitOfWork.Commit();
        }
        public virtual int Update(T t) {
            unitOfWork.Set<T>().Update(t);
            return unitOfWork.Commit();
        }
    }
}
