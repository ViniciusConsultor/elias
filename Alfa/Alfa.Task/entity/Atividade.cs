using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;
using Alfa.Task.Enum;

namespace Alfa.Task.Entity
{
    public class Atividade : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual TimeSpan Estimativa { get; set; }
        public virtual TimeSpan Duracao { get; set; }
        public virtual EnumStatus Status { get; set; }
        public virtual EnumComplexidade Complexidade { get; set; }
        public virtual bool Planejada { get; set; }

        public virtual Profissional Profissional { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual IEnumerable<Periodo> Periodos { get; set; }

        public override IEnumerable<string> Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                yield return "Informe a descrição.";

        }
    }
}
