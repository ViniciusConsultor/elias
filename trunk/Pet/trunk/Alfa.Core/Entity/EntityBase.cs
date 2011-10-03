using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
