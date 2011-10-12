using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Alfa.Core.Unit
{
    public interface IUnitOfWork
    {
        ITransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
