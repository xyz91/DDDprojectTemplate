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
        /// <summary>
        /// 映射model
        /// </summary>
        /// <typeparam name="S">源类型</typeparam>
        /// <typeparam name="M">目标类型</typeparam>
        /// <param name="s">源对象</param>
        /// <returns></returns>
         M Map<S, M>(S s);
        /// <summary>
        /// entity映射为dto
        /// </summary>
        /// <param name="obj">源对象</param>
        /// <returns></returns>
        D Map(T obj);
       /// <summary>
       /// dto映射为entity
       /// </summary>
       /// <param name="obj"></param>
       /// <returns></returns>
        T Map(D obj);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         T GetById(K id);
        /// <summary>
        ///  根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsnyc(K id);
        /// <summary>
        /// 根据id获取dto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         D GetDTOById(K id);
        /// <summary>
        /// 根据id获取dto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<D> GetDTOByIdAsnyc(K id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
         int Insert(T t);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> InsertAsync(T t);
        /// <summary>
        /// dto转model后添加
        /// </summary>
        /// <param name="d">dto</param>
        /// <returns></returns>
         int Insert(D d);
        Task<int> InsertAsnyc(D d);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         int Delete(K id);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(K id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
         int Delete(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
         int Update(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T t);
        /// <summary>
        /// dto转model后更新
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
         int Update(D d);
        /// <summary>
        /// dto转model后更新
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(D d);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
         PagingDTO<D> Search(int pageIndex, int pageSize);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        Task<PagingDTO<D>> SearchAsync(int pageIndex, int pageSize);

    }
}
