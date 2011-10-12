using System;
using System.Linq;
using Alfa.Core.Container;
using Alfa.Core.Exception;
using Alfa.Core.Repository;
using Alfa.Pet.Model;
using System.Collections.Generic;

namespace Alfa.Pet.Test
{
    class Program
    {
        static void Main()
        {
            IHandlerException handler = Locator.GetComponet<IHandlerException>();

            handler.DisplayMessage("inicio do caso de testes ");
            handler.DisplayMessage("excluindo registros pre existentes");

            IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();

            List<Marca> marcas = rep.GetAll().ToList();
            foreach (Marca marca in marcas)
                rep.DeleteOnSubmit(marca);

            rep.SubmitChanges();

            handler.DisplayMessage("registros excluidos");

            handler.DisplayMessage("incluindo um registro");

            Marca entity = new Marca();
            entity.Descricao = "charopinho";

            entity.Produtos.Add(new Produto { Descricao = "coca", Preco = 1, ProdutoTipo = new ProdutoTipo { Descricao = "refri" } });
            rep.InsertOnSubmit(entity);



            Console.ReadLine();

            handler.DisplayMessage("registros incluidos");

            handler.DisplayMessage("exibindo registros incluidos");


            foreach (Marca marca in rep.GetAll())
                handler.DisplayMessage(string.Format("Marca: {0}, Produto: {1}, Tipo de Produto: {2}",
                    marca.Descricao, marca.Produtos[0].Descricao, marca.Produtos[0].ProdutoTipo.Descricao));

            Console.Read();


        }
    }
}