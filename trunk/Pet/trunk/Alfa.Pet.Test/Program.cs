using System;
using System.Linq;
using Alfa.Core.Container;
using Alfa.Core.Exception;
using Alfa.Core.Repository;
using Alfa.Pet.Model;

namespace Alfa.Pet.Test
{
    class Program
    {
        static void Main()
        {
            Locator.GetComponet<IHandlerException>().DisplayMessage("teste");
            Locator.GetComponet<IHandlerException>().Log("e não e que funciona");
            Console.ReadLine();

            //Marca marca = new Marca();

            //List<String> colunas = marca.Properties();

            //Locator.GetComponet<IRepository<Marca>>().InsertOnSubmit(marca);
            //foreach (string erro in marca.Validate())
            //{
            //    Console.WriteLine(erro);
            //}
            //Console.Read();

            //Locator.GetComponet<CadastroService>().Incluir();
            //Console.WriteLine(Locator.GetComponet<IRepository<Produto>>().GetAll().Count());
            //Console.ReadLine();

            //TesteDeInclusao();
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