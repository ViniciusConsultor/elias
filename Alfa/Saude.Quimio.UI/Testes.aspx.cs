using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alfa.Core.Container;
using Saude.Quimio.Entity;
using Alfa.Core.Repository;

namespace Saude.Quimio.UI
{
    public partial class Testes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pergunta pergunta = Locator.GetComponet<IRepository<Pergunta>>().GetById(1);

            pergunta.Ordem += 1;

            System.Threading.Thread.Sleep(7000);


            Locator.GetComponet<IRepository<Pergunta>>().Save(pergunta);
        }
        private void Incluir()
        {
            Pergunta pergunta = new Pergunta();
            pergunta.Descricao = "Já fez tratamento antes?";
            pergunta.Ordem = 1;
            pergunta.RespostaExclusiva = true;

            Locator.GetComponet<IRepository<Pergunta>>().Save(pergunta);
        }
    }
}