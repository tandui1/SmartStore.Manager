using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Repository.Interface.Base
{
  public  interface IBaseRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> exp = null);
        bool IsExist(Expression<Func<T, bool>> exp);
        IQueryable<T> Find(Expression<Func<T, bool>> exp = null);

        IQueryable<T> Find(Expression<Func<T, bool>> exp, Action<Orderable<T>> order, ref int totalRecord, int pageIndex = 1, int pageSize = 10, string orderby = "");

        int GetCount(Expression<Func<T, bool>> exp = null);

        T Add(T entity);

        void BatchAdd(T[] entities);

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update(T entity);

        T Delete(T entity);
        ///// <summary>
        ///// 根据oid
        ///// </summary>
        ///// <param name="oid"></param>
        ///// <returns></returns>
        //bool Delete(long oid);
        /// <summary>
        /// 按指定的ID进行批量更新
        /// </summary>
        void Update(Expression<Func<T, object>> identityExp, T entity);

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        int Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);
        /// <summary>
        /// 批量删除
        /// </summary>
        int Delete(Expression<Func<T, bool>> exp);

        void Save();
        /// <summary>
        /// 执行sql语句(尽量不要用这个sql执行)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSql(string sql);
        /// <summary>
        /// 查询sql语句(尽量不要用这个sql查询)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<T> SqlQuery(string sql);
        /// <summary>
        /// 查询sql语句(尽量不要用这个sql查询)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> SqlQuery(string sql, params object[] parameters);
        /// <summary>
        /// 执行sql语句(尽量不要用这个sql执行)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, params object[] parameters);
        /// <summary>
        /// 查询所有的排序
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> where, Action<Orderable<T>> order);
    }
}
