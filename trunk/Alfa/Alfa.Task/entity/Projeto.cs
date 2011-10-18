using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Task.Entity
{
    public class Projeto : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        protected virtual IEnumerable<Atividade> Atividades { get; set; }
        public virtual IEnumerable<Profissional> Profissionais { get; set; }

    }
}
