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
            Alfa.Core.Mapper.FluentNHibernateConfigurationBuilder.Create();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pergunta pergunta = new Pergunta();
            pergunta.Descricao = "Já fez tratamento antes?";
            pergunta.Ordem = 1;
            pergunta.RespostaExclusiva = true;

            Locator.GetComponet<IRepository<Pergunta>>().Save(pergunta);
            //Pergunta pergunta = Locator.GetComponet<IRepository<Pergunta>>().GetById(1);
            //pergunta.Ordem += 1;
            //System.Threading.Thread.Sleep(7000);
            //Locator.GetComponet<IRepository<Pergunta>>().Save(pergunta);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetById(1);
            pergunta.Descricao = null;
            rep.Save(pergunta);            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetAll().Where(p => p.Id > 1).First();
            rep.Delete(pergunta);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetById(1);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetAll().Where(p => p.Ordem < 5).SingleOrDefault();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetById(1);

            OpcaoResposta opcaoResposta = new OpcaoResposta();
            opcaoResposta.Descricao = "Sim";
            opcaoResposta.Ordem = 1;
            opcaoResposta.RequerJustificativa = true;

            pergunta.AddOpcaoResposta(opcaoResposta);

            OpcaoResposta opcaoResposta2 = new OpcaoResposta();
            opcaoResposta2.Descricao = "Sim";
            opcaoResposta2.Ordem = 1;
            opcaoResposta2.RequerJustificativa = true;

            pergunta.AddOpcaoResposta(opcaoResposta2);

            rep.Save(pergunta);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            IRepository<Pergunta> rep = Locator.GetComponet<IRepository<Pergunta>>();
            Pergunta pergunta = rep.GetById(1);

            OpcaoResposta opcaoResposta = pergunta.OpcoesDeResposta.First();
            pergunta.RemoveProduto(opcaoResposta);

            rep.Save(pergunta);
        }
    }
}