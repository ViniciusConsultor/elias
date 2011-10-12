using System.Linq;
using Alfa.Core.Entity;

namespace Alfa.Core.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void InsertOnSubmit(T entity);
        void DeleteOnSubmit(T entity);
        void SubmitChanges();
    }

    public interface IRepository
    {
        object GetById(int id);
        IQueryable GetAll();
        void InsertOnSubmit(object entity);
        void DeleteOnSubmit(object entity);
        void SubmitChanges();
    }
}