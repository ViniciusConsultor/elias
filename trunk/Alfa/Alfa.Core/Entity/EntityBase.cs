using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Alfa.Core.Entity
{
    public class EntityBase
    {

        /// <summary>
        /// Método IsValid verifica se atributos obrigatórios foram preenchidos ou estão em estado válido 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid()
        {
            return Validate().Count() == 0;
        }
        /// <summary>
        /// Método Validate retorna lista de atributos obrigatórios não preenchidos ou em estado inválido
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> Validate()
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
