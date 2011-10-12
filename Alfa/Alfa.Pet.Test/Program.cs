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
            IHandlerMessage handler = DefaultHandlerMessage.Instance;

            handler.Show("inicio do caso de testes ");
            handler.Show("excluindo registros pre existentes");

            IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();

            List<Marca> marcas = rep.GetAll().ToList();
            foreach (Marca marca in marcas)
                rep.Delete(marca);

            rep.SubmitChanges();

            handler.Show("registros excluidos");

            handler.Show("incluindo um registro");

            Marca entity = new Marca();
            entity.Descricao = "charopinho";

            entity.Produtos.Add(new Produto { Descricao = "coca", Preco = 1, ProdutoTipo = new ProdutoTipo { Descricao = "refri" } });
            rep.Save(entity);



            Console.ReadLine();

            handler.Show("registros incluidos");

            handler.Show("exibindo registros incluidos");


            foreach (Marca marca in rep.GetAll())
                handler.Show(string.Format("Marca: {0}, Produto: {1}, Tipo de Produto: {2}",
                    marca.Descricao, marca.Produtos[0].Descricao, marca.Produtos[0].ProdutoTipo.Descricao));

            Console.Read();


        }
    }
}