using System.Linq;
using Alfa.Core.Mapper;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;
using Alfa.Core.Validation;
using Alfa.Core.Entity;

namespace Alfa.Core.Repository
{
    public class NHibernateRepository<T> : IRepository<T>, IRepository where T : EntityBase
    {

        private readonly ISessionManager sessionManager;
        private IValidator validator;

        public NHibernateRepository(ISessionManager sessionManager, IValidator validator)
        {
            this.sessionManager = sessionManager;
            this.validator = validator;
        }

        private ISession Session
        {
            get
            {
                return this.sessionManager.OpenSession();
            }
        }

        public T GetById(int id)
        {
            return Session.Load<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return Session.Linq<T>();
        }

        public void InsertOnSubmit(T entity)
        {
            validator.Assert(entity.Validate(), true);
            Session.Save(entity);
        }

        public void DeleteOnSubmit(T entity)
        {
            Session.Delete(entity);
        }

        public void SubmitChanges()
        {
            Session.Flush();
        }

        object IRepository.GetById(int id)
        {
            return GetById(id);
        }

        IQueryable IRepository.GetAll()
        {
            return GetAll();
        }

        void IRepository.InsertOnSubmit(object entity)
        {
            InsertOnSubmit((T)entity);
        }

        void IRepository.DeleteOnSubmit(object entity)
        {
            DeleteOnSubmit((T)entity);
        }
    }
}