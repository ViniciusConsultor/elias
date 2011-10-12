using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Compra : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual IList<ItemDeCompra> ItensDeCompra { get; set; }
        public Compra()
        {
            ItensDeCompra = new List<ItemDeCompra>();
        }
        public virtual decimal Total()
        {
            return ItensDeCompra.Sum(item => item.Total());
        }
    }
}
