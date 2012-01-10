using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Alfa.Core.Mapper
{
    public class NotNullPropertyConvention : IPropertyConvention
    {
        public bool Accept(IPropertyInstance target)
        {
            return !IsNullableProperty(target);
        }

        public void Apply(IPropertyInstance target)
        {
            if (IsNullableProperty(target))
                target.Not.Nullable();

        }

        private bool IsNullableProperty(IPropertyInstance target)
        {
            var type = target.Property.PropertyType;
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }       
    }
}
