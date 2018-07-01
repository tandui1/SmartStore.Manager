using SmartStore.Manager.Core.Base;
using SmartStore.Manager.Core.Base.Impl;
using SmartStore.Manager.Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Repository
{
    public class EntityBaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext dbContext;
        private IDbSet<T> entities;

        public IDbSet<T> Entities {
            get
            {
                if (entities == null)
                    entities = dbContext.Set<T>();
                return entities;
            }
        }
        public long Add(T entity)
        {
            entity = InsertEntity(entity);
            this.dbContext.SaveChanges();
            return entity.OID;
        }
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }
        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        //public void Commit()
        //{
        //    throw new NotImplementedException();
        //}

        public int Count()
        {
            return dbContext.Set<T>().Count();
        }

        public void Delete(T entity)
        {
          
            this.Entities.Remove(entity);
            this.dbContext.SaveChanges();
        }
        public void Delete(long oid)
        {
            var entity = GetSingle(oid);
            this.Entities.Remove(entity);
            this.dbContext.SaveChanges();
        }
        public bool DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entity= this.GetSingle(predicate);
            this.Entities.Remove(entity);
            return this.dbContext.SaveChanges()>0;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, Action<Orderable<T>> order, int pageIndex, int pageSize, ref int totalRecord)
        {
            var query = this.Table;

            query = query.Where(where);

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
        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref int totalRecord)
        {
            return GetAll(where, pageIndex, pageSize, ref totalRecord);
        }

        public IQueryable<T> GetAll(int pageIndex, int pageSize, ref int totalRecord)
        {
            return GetAll(null, null, pageIndex, pageSize, ref totalRecord);
        }
        public IQueryable<T> GetAll()
        {
            return Table.AsNoTracking();
        }

        public T GetSingle(long id)
        {
            return dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.OID.Equals(id));
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.Where(predicate).FirstOrDefault();
        }

        public T InsertEntity(T entity)
        {
          return  this.entities.Add(entity);
        }

        public long Update(T entity)
        {
            entity = UpdateEntity(entity);
            this.dbContext.SaveChanges();
            return entity.OID;
        }

        public T UpdateEntity(T entity)
        {
            AttachIfNot(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        protected virtual void AttachIfNot(T entity)
        {
            if (!this.Entities.Local.Contains(entity))
            {
                this.Entities.Attach(entity);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> where)
        {
            var query = this.Table;
            query = query.Where(where);
            return query;
        }
    }
}
