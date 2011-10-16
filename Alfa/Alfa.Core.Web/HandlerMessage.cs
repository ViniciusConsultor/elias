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
        public void Show(string script)
        {
            string formatedScript = script;
            if (!script.Contains("alert") && !script.Contains("confirm"))
                formatedScript = string.Format("alert('{0}');", script);

            if (HttpContext.Current != null)
            {
                Page page = HttpContext.Current.CurrentHandler as Page;

                if (ScriptManager.GetCurrent(page) != null && ScriptManager.GetCurrent(page).IsInAsyncPostBack)
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "script_de_erro", formatedScript, true);
                else
                    page.ClientScript.RegisterStartupScript(page.GetType(), "script_de_erro", formatedScript, true);

            }
        }
    }
}
