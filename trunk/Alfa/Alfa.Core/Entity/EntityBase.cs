using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Alfa.Core.Entity
{
    public class EntityBase
    {
        public virtual bool IsValid()
        {
            return Validate().Count() == 0;
        }
        public virtual List<string> Validate()
        {
            return new List<string>();
        }
        public virtual List<String> Properties()
        {
            return Properties(true);
        }
        public virtual List<String> Properties(bool primitiveColumnsOnly)
        {
            return (from item in this.GetType().GetProperties()
                    where TypeValid(item, primitiveColumnsOnly)
                    select item.Name).ToList();

        }
        public virtual String ValueFrom(String propertyName)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperties().SingleOrDefault(item => item.Name == propertyName);
            if (propertyInfo == null) return String.Empty;
            return propertyInfo.GetValue(this, null).ToString();
        }

        private bool TypeValid(PropertyInfo property, bool primitiveColumnsOnly)
        {
            if (!primitiveColumnsOnly) return true;
            return property.PropertyType.IsPrimitive ||
                property.PropertyType == typeof(String) ||
                (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));

        }

    }
}
