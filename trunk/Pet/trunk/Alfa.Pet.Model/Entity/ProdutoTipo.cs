using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class ProdutoTipo : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public ProdutoTipo()
        {
            Produtos = new List<Produto>();
        }
    }
}
