using System.Linq;
using Alfa.Core.Mapper;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;
using Alfa.Core.Validation;
using Alfa.Core.Entity;
using Alfa.Core.Rule;

namespace Alfa.Core.Repository
{
    public class NHibernateRepository<T> : IRepository<T>, IRepository where T : EntityBase
    {
        private IPersistenceRule<T> persistenceRule = DefaultPersistenceRule<T>.Instance;
       
        private readonly ISessionManager sessionManager;

        public NHibernateRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public NHibernateRepository(ISessionManager sessionManager, IPersistenceRule<T> ppersistenceRule)
        {
            this.sessionManager = sessionManager;
            this.persistenceRule = ppersistenceRule;
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

        public bool Save(T entity)
        {
            persistenceRule.OnSave(entity);
            Session.Save(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            persistenceRule.OnDelete(entity);
            Session.Delete(entity);
            return true;
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

        bool IRepository.Save(object entity)
        {
            return Save((T)entity);
        }

        bool IRepository.Delete(object entity)
        {
            return Delete((T)entity);
        }
    }
}