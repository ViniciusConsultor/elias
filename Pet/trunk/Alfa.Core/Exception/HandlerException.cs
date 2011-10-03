using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Container;
using Alfa.Core.Unit;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using Castle.Core.Logging;

namespace Alfa.Core.Exception
{
    public class HandlerException : IHandlerException
    {
        public ILogger Logger
        {
            get;
            set;
        }
        public void TratarException(System.Exception ex)
        {
            desfazerTransacao();
            exibirMensagem(obterMensagem(ex));
            logarErro(ex);
        }

        private void logarErro(System.Exception ex)
        {
            if (!regraDeNegocioViolada(ex))
                Logger.Error(ex.Message);
        }
        private bool regraDeNegocioViolada(System.Exception ex)
        {
            return ex.GetType() == typeof(BussinessException);
        }
        private string obterMensagem(System.Exception ex)
        {
            string mensagem = "Não foi possível completar esta operação.";

            if (regraDeNegocioViolada(ex)) return (ex.Message);

            return mensagem;
        }
        private void desfazerTransacao()
        {
            try
            {
                Locator.GetComponet<IUnitOfWork>().Rollback();
            }
            catch (System.Exception ex)
            {
                 Logger.Error("Não foi possível desfazer a transação. Detalhes:" + ex.Message);
            }
        }
        private void exibirMensagem(string p)
        {

            if (HttpContext.Current != null)
            {
                Page page = HttpContext.Current.CurrentHandler as Page;

                if (ScriptManager.GetCurrent(page).IsInAsyncPostBack)
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "script_de_erro", "alert('" + p + "');", true);
                else
                    page.ClientScript.RegisterStartupScript(page.GetType(), "script_de_erro", "alert('" + p + "');", true);

            }
            else if (Application.OpenForms.Count > 0)
            {

                MessageBox.Show(p, "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine(p);
            }
        }
    }
}
