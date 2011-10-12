using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;

namespace Alfa.Pet.Model
{
    public class Estoque : EntityBase
    {
        public virtual int Id { get; private set; }
        public virtual IList<ProdutoEstoque> ProdutosEmEstoque { get; set; }

        public Estoque()
        {
            ProdutosEmEstoque = new List<ProdutoEstoque>();
        }

        public virtual void IncluirItem(Produto pProduto, int pQuantidade)
        {
            var itemDeEstoque = ProdutosEmEstoque.FirstOrDefault(item => item.Produto.Id == pProduto.Id);
            if (itemDeEstoque != null)
            {
                itemDeEstoque.Quantidade += pQuantidade;
            }
            else
                ProdutosEmEstoque.Add(new ProdutoEstoque { Produto = pProduto, Quantidade = pQuantidade });
        }

        public virtual void DeduzirItem(Produto pProduto, int pQuantidade)
        {
            var itemDeEstoque = ProdutosEmEstoque.FirstOrDefault(item => item.Produto.Id == pProduto.Id);
            if (itemDeEstoque != null)
            {
                itemDeEstoque.Quantidade -= pQuantidade;
            }
        }
    }
}
