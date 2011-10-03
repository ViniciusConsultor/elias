using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Cliente : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual DateTime Nascimento { get; set; }
        public virtual string Telefone { get; set; }
    }
}
