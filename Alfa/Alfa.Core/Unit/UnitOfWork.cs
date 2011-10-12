using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;


namespace Alfa.Core.Unit
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ISessionManager sessionManager;
        private ITransaction transaction;

        public UnitOfWork(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        #region IUnitOfWork Members

        public ITransaction BeginTransaction()
        {
            transaction = sessionManager.OpenSession().BeginTransaction();
            return transaction;
        }

        public void Commit()
        {
            if (transaction.IsActive)
                transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Rollback();
        }

        #endregion
    }
}
