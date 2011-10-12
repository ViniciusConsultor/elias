using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core;
using Alfa.Core.Container;
using Alfa.Core.Repository;
using Alfa.Core.Unit;
using NHibernate;

namespace Alfa.Pet.Model.Services
{
    public class CadastroService
    {
        IUnitOfWork mIUnitOfWork = null;

        public CadastroService(IUnitOfWork unit)
        {
            mIUnitOfWork = unit;
        }

        public void Incluir()
        {
            //using (ITransaction tx = mIUnitOfWork.BeginTransaction())
            //{
            mIUnitOfWork.BeginTransaction();
            Produto produto = new Produto();
            produto.Descricao = "teste";
            produto.Preco = 0;

            Locator.GetComponet<IRepository<Produto>>().Save(produto);
            //    tx.Commit();
            //}
            mIUnitOfWork.Rollback();
        }

        public void IncluirProduto(Produto produto, int quantidade)
        {
            Locator.GetComponet<IRepository<Produto>>().Save(produto);
            Locator.GetComponet<IRepository<Produto>>().GetById(1);
            IQueryable<Estoque> estoques = Locator.GetComponet<IRepository<Estoque>>().GetAll();

            var total = estoques.Count();

            Console.Write(total);
            Console.Read();
            //if (estoque == null)
            //    estoque = new Estoque();

            //estoque.IncluirItem(produto, quantidade);
        }
    }
}