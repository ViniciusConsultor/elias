using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Repository;
using Alfa.Core.Entity;
using System.Collections.ObjectModel;

namespace Alfa.Pet.Model
{
    public class Marca : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        
        private IList<Produto> produtos = new List<Produto>();
        public virtual IEnumerable<Produto> Produtos
        {
            get { return produtos; }
            private set { produtos = value.ToList(); }

        }
        public Marca()
        { }

        public virtual void AddProduto(Produto produto)
        {
            produtos.Add(produto);
            produto.Marca = this;
        }
        public virtual void RemoveProduto(Produto produto)
        {            
            produtos.Remove(produto);
        }
        
        public override IEnumerable<string> Validate()
        {
            if (Id < 0)
                yield return "Id não pode ser menor que zero.";

            if (string.IsNullOrEmpty(Descricao))
                yield return "Informe a descrição.";

        }
    }
}
