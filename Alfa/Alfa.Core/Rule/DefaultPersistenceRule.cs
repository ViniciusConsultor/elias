using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;
using Alfa.Core.Validation;

namespace Alfa.Core.Rule
{
    public class DefaultPersistenceRule<T> : IPersistenceRule<T> where T : EntityBase
    {

        #region singleton
        private static volatile DefaultPersistenceRule<T> instance;
        private static object syncRoot = new Object();

        private DefaultPersistenceRule()
        { }

        public static DefaultPersistenceRule<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DefaultPersistenceRule<T>();
                    }
                }

                return instance;
            }
        }
        #endregion

        public DefaultPersistenceRule(T entity) { }

        public DefaultPersistenceRule(IValidator pvalidator)
        {
            validator = pvalidator;
        }

        private IValidator validator = DefaultValidator.Instance;
        protected IValidator Validator
        {
            get { return validator; }
            set { validator = value; }
        }

        public virtual void OnSave(T entity)
        {
            validator.Assert(entity.Validate(), true);
        }

        public virtual void OnDelete(T entity)
        {
        }
    }
}
