using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Exception;
using System.Web;
using System.Web.UI;

namespace Alfa.Core.Web
{
    public class HandlerMessage : IHandlerMessage
    {
        public void Show(string message)
        {
            ExecuteScript("alert('" + message + "');");
        }

        public void ExecuteScript(string script)
        {
            if (HttpContext.Current != null)
            {
                Page page = HttpContext.Current.CurrentHandler as Page;

                if (System.Web.HttpContext.Current.Items["callCrossHttpModule"] != null || page == null)
                {   //chamada via module ou se não tem um contexto de pagina associado
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>" + script + "</SCRIPT>");
                    return;
                }

                if (ScriptManager.GetCurrent(page) != null && ScriptManager.GetCurrent(page).IsInAsyncPostBack)
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "script_de_erro", script, true);
                else
                    page.ClientScript.RegisterStartupScript(page.GetType(), "script_de_erro", script, true);
            }
        }
    }
}
