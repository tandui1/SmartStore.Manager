using SmartStore.Manager.Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SmartStore.Manager.Core.Base.Impl;
using System.Data.Entity;

namespace SmartStore.Manager.Core.Repository
{
  public  interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        IDbSet<T> Entities { get; }

        int Count();

        T GetSingle(long id);

        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll(Expression<Func<T, bool>> where, Action<Orderable<T>> order, int pageIndex, int pageSize, ref int totalRecord);
        IQueryable<T> GetAll(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref int totalRecord);
        IQueryable<T> GetAll(int pageIndex, int pageSize, ref int totalRecord);
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        long Add(T entity);

        long Update(T entity);

        void Delete(T entity);

        bool DeleteWhere(Expression<Func<T, bool>> where);

        T InsertEntity(T entity);
        void Delete(long oid);
        T UpdateEntity(T entity);
    }
}
