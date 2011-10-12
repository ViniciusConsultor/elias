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

namespace Alfa.Pet.Web
{

    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Locator.GetComponet<IHandlerException>().DisplayMessage("teste");
            Locator.GetComponet<IHandlerException>().Log("e não e que funciona");
            Button1_Click(null, null);
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
            rep.InsertOnSubmit(a);

            Marca marca1 = new Marca { Descricao = "pet" };
            rep.InsertOnSubmit(marca1);
            Marca marca2 = new Marca { Descricao = "pet" };
            rep.InsertOnSubmit(marca2);


        }
    }
}
