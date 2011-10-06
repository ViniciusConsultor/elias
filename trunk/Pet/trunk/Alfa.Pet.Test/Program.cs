using Alfa.Core.Container;
using Alfa.Core.Repository;
using Alfa.Pet.Model;
using System.Linq;
using System;
using Alfa.Core.Mapper;

using Alfa.Pet.Model.Services;
using System.Collections.Generic;


namespace Alfa.Pet.Test
{
    class Program
    {
        static void Main()
        {
           // log4net.Config.XmlConfigurator.Configure();
            //ILogger logger = NullLogger.Instance;
            //try
            //{
            //    throw new ApplicationException("lixo");

            //}
            //catch
            //{
            //    logger.Error("teste de erro");
            //}
            //return;
            Marca marca = new Marca();

            List<String> colunas = marca.Properties();



            Locator.GetComponet<IRepository<Marca>>().InsertOnSubmit(marca);
            foreach (string erro in marca.Validate())
            {
                Console.WriteLine(erro);
            }
            Console.Read();
            
            //Locator.GetComponet<CadastroService>().Incluir();
            //Console.WriteLine(Locator.GetComponet<IRepository<Produto>>().GetAll().Count());
            //Console.ReadLine();

            //TesteDeInclusao();
        }
        static void Teste1()
        {
            //var sessionFactory = NHibernateSessionHelper<Cliente>.CreateSessionFactory(true);

            //using (var session = sessionFactory.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        var produto = new Produto { Descricao = "PetSuite" };
            //        var tipoProduto = new ProdutoTipo { Descricao = "Ração" };

            //        produto.ProdutoTipo = tipoProduto;
            //        tipoProduto.Produtos.Add(produto);

            //        session.SaveOrUpdate(produto);

            //        transaction.Commit();
            //    }
            //}
            //Console.ReadKey();
        }
        static void Teste2()
        {
            //var registers = Locator.GetComponet<IRepository<Produto>>().GetAll();
            //Console.WriteLine(registers.Count());
            //Console.ReadLine();

           // FluentNHibernateConfigurationBuilder.CreateDatabase();
            Console.WriteLine("banco regerado");
            Console.ReadKey();
        }
        static void TesteDeInclusao()
        {
            Console.WriteLine("teste de inclusão e recuperação de registros");
            Marca marca = new Marca();
            marca.Descricao = "Foster";

            Locator.GetComponet<IRepository<Marca>>().InsertOnSubmit(marca);

            IRepository<Marca> repository = Locator.GetComponet<IRepository<Marca>>();
            Marca marcaGravada = repository.GetAll().Where(item => item.Descricao == "Foster").SingleOrDefault();

            if (marcaGravada != null)
                Console.WriteLine(marcaGravada.Descricao + "=" + marcaGravada.Id.ToString());
            else
                Console.WriteLine("marca nao encontrada");

            Console.ReadKey();

        }
    }
}