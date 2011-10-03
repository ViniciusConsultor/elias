using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class ItemDeVenda : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }

        public virtual decimal Total()
        {
            return Produto.Preco * Quantidade;
        }

    }
}
