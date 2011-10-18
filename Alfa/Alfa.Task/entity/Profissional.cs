using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Task.Entity
{
    public class Profissional : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Login { get; set; }
        public virtual IEnumerable<Projeto> Projetos { get; set; }

    }
}
