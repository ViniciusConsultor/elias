using System.Linq;
using Alfa.Core.Entity;

namespace Alfa.Core.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        bool Save(T entity);
        bool Delete(T entity);
        void SubmitChanges();
    }

    public interface IRepository
    {
        object GetById(int id);
        IQueryable GetAll();
        bool Save(object entity);
        bool Delete(object entity);
        void SubmitChanges();
    }
}