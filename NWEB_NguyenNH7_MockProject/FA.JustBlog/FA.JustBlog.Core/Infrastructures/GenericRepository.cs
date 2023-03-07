using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JustBlogContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(JustBlogContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(int key)
        {
            Delete(GetById(key));
        }

        public virtual T Find(int key)
        {
            return this.dbSet.Find(GetById(key));
        }

        public virtual IList<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public virtual T GetById(int key)
        {
            return this.dbSet.Find(key);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}