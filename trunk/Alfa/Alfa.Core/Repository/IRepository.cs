using System.Linq;
using Alfa.Core.Entity;

namespace Alfa.Core.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
        void SubmitChanges();
    }

    public interface IRepository
    {
        object GetById(int id);
        IQueryable GetAll();
        void Save(object entity);
        void Delete(object entity);
        void SubmitChanges();
    }
}