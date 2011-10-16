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

                if (ScriptManager.GetCurrent(page) != null && ScriptManager.GetCurrent(page).IsInAsyncPostBack)
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "script_de_erro", script, true);
                else
                    page.ClientScript.RegisterStartupScript(page.GetType(), "script_de_erro", script, true);

            }
        }
    }
}
