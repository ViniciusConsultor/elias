using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Repository;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Marca : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public Marca()
        {
            Produtos = new List<Produto>();
        }


        public override bool IsValid()
        {
            return Validate().Count() == 0;
        }
        public override List<string> Validate()
        {
            List<string> erros = new List<string>();
            if (Id < 0)
                erros.Add("Id não pode ser menor que zero.");

            if (string.IsNullOrEmpty(Descricao))
                erros.Add("Informe a descrição.");

            return erros;
        }
    }
}
