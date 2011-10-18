using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Task.Entity
{
    public class Periodo : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual DateTime Inicio { get; set; }
        public virtual DateTime Fim { get; set; }
        public virtual string Nota { get; set; }
    }
}
