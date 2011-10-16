using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Produto : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        /// <summary>
        /// Preço se refere a venda
        /// </summary>
        public virtual decimal Preco { get; set; }
        public virtual ProdutoTipo ProdutoTipo { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
