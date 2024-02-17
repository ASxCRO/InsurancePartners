using Partners.Web.Data.Entities;
using System.Collections.Generic;

namespace Partners.Web.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        void Remove(int id);

        void Update(T item);

        T FindByID(int id);

        IEnumerable<T> FindAll();
    }
}