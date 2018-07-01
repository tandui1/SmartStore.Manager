using EntityFramework.Extensions;
using Infrastructure.Core;
using Infrastructure.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;


namespace SmartStore.Manager.Repository.Interface.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        SmartStoreDBContext Context = new SmartStoreDBContext();
       // private readonly IDbContext dbContext;
        private IDbSet<T> entities;
        public IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = Context.Set<T>();
                return entities;
            }
        }
       
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }
        public T Add(T entity)
        {
            if (string.IsNullOrEmpty(entity.OID.ToString()))
            {
                entity.OID = Guid.NewGuid();
            }
           var model= Context.Set<T>().Add(entity);
            Save();
            return model;
        }
        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }

        public void BatchAdd(T[] entities)
        {
            foreach (var entity in entities)
            {
                entity.OID = Guid.NewGuid();
            }
            Context.Set<T>().AddRange(entities);
            Save();
        }

        public T Delete(T entity)
        {
           var a= Context.Set<T>().Remove(entity);
            Save();
            return a;
        }

        public int Delete(Expression<Func<T, bool>> exp)
        {
          return  Context.Set<T>().Where(exp).Delete();
        }

        public int ExecuteSql(string sql)
        {
              return ExecuteSql(sql,null);
        }
        public int ExecuteSql(string sql, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlCommand(sql,parameters);
        }
        public IList<T> SqlQuery(string sql)
        {
            return SqlQuery(sql, null);
        }
        public IList<T> SqlQuery(string sql, params object[] parameters)
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).ToList();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> where, Action<Orderable<T>> order)
        {
            var query = this.Table;

            query = query.Where(where);

            var orderable = new Orderable<T>(query);

            order(orderable);

            query = orderable.Queryable;
            return query;
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> exp , Action<Orderable<T>> order ,ref int totalRecord, int pageIndex = 1, int pageSize = 10, string orderby = "")
        {
            var query = this.Table;

            query = query.Where(exp);

            var orderable = new Orderable<T>(query);

            order(orderable);

            query = orderable.Queryable;

            if (totalRecord <= 0)
            {
                totalRecord = query.Count();
            }

            int pages = totalRecord / pageSize;

            if (totalRecord % pageSize > 0)
                pages++;

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }

        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }
     
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new Exception(e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }
        private  void AttachIfNot(T entity)
        {
            if (!this.Entities.Local.Contains(entity))
            {

                this.Entities.Attach(entity);
            }
        }
        public void Update(T entity)
        {
            try
            {
                AttachIfNot(entity);
                var entry = this.Context.Entry(entity);
                //todo:如果状态没有任何更改，会报错
                entry.State = EntityState.Modified;
                Save();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Expression<Func<T, object>> identityExp, T entity)
        {
            Context.Set<T>().AddOrUpdate(identityExp, entity);
            Save();
        }

        public int Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
         return  Context.Set<T>().Where(where).Update(entity);
        }
    }
}
