using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfa.Pet.Model;
using Alfa.Pet.Model.Services;
using Alfa.Core.Repository;
using Alfa.Core.Container;
using Alfa.Core.Exception;
using Alfa.Core.Web;
using Alfa.Core.Mapper;

namespace Alfa.Pet.Web
{

    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //Cliente cli = new Cliente();
            //cli.Nome = "fabio";
            //cli.Nascimento = DateTime.Now.AddYears(-21);
            //IRepository<Cliente> rep = Locator.GetComponet<IRepository<Cliente>>();
            //Cliente persistete = rep.GetById(5);
            //rep.Save(persistete);

            //Marca marca = new Marca();
            //IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();
            //rep.Save(marca);


            base.Alert("sucesso");
            base.ExecuteScript("alert('sera');");
            base.AlertRedirect("voce não pode", "about.aspx");
            //Locator.GetComponet<IHandlerMessage>().Show("teste");
            //Locator.GetComponet<IHandlerException>().Log("e não e que funciona");
            //Button1_Click(null, null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();

            rep.GetAll().ToList().ForEach(
               item => Response.Write(item.Id + " " + item.Descricao + "<br/>"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //IRepository<Cliente> rep = Locator.GetComponet<IRepository<Cliente>>();

            //Cliente pf = Cliente.CreatePessoaFisica("tiburcio", "22222222", "123", DateTime.Now);
            //Cliente pj = Cliente.CreatePessoaJuridica("patric", "33333333", "999");

            //rep.InsertOnSubmit(pf);
            //rep.InsertOnSubmit(pj);

            IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();

            Marca a = new Marca();
            rep.Save(a);

            Marca marca1 = new Marca { Descricao = "pet" };
            rep.Save(marca1);
            Marca marca2 = new Marca { Descricao = "pet" };
            rep.Save(marca2);


        }
    }
}
