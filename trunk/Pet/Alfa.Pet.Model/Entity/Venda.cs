using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Venda : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual DateTime Data { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual IList<ItemDeVenda> ItensDeVenda { get; set; }

        public Venda()
        {
            ItensDeVenda = new List<ItemDeVenda>();
        }

        public virtual decimal Total()
        {
            return ItensDeVenda.Sum(item => item.Total());
        }
    }
}
