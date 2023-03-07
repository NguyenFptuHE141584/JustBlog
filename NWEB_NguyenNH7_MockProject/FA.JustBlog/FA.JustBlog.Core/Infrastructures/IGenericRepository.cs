using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IGenericRepository<T> where T : class
    {
        T Find(int key);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int key);

        IList<T> GetAll();

        T GetById(int key);
    }
}