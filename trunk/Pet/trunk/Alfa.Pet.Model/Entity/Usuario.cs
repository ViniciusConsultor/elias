using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Usuario : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Email { get; set; }
    }
}
