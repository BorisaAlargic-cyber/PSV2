using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public ModelContext ModelContext
        {
            get { return Context as ModelContext; }
        }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public virtual IEnumerable<TEntity> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public virtual PageResponse<TEntity> GetPage(Pager pager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Search(string term)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
    }
}
