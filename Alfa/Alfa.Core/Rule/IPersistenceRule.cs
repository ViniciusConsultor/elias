using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Core.Rule
{
    public interface IPersistenceRule<T> where T : EntityBase
    {
        void OnSave(T entity);
        void OnDelete(T entity);
    }
}
