using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Entity;
using Alfa.Core.Container;
using Alfa.Core.Exception;

namespace Alfa.Core.Web
{
    public class PageBase<T> : PageBase where T : EntityBase
    {
        /// <summary>
        /// Id - Identificador de um objeto
        /// </summary>
        protected override int? Id
        {
            get
            {
                if (ViewState["_ID"] == null) return null;
                return Convert.ToInt32(ViewState["_ID"]);
            }
            set
            {
                ViewState["_ID"] = value;
            }
        }
        /// <summary>
        /// Método responsável pelo carregamento inicial da pagina
        /// </summary>
        protected override void PageLoad()
        {

        }
        /// <summary>
        /// Metodo responsável por limpar os controles da pagina 
        /// </summary>
        protected override void PageClear()
        {
            Id = null;
        }
        /// <summary>
        /// Método responsável pelo carregamento dos controles da página 
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void PageFill(T entity)
        {

        }
        /// <summary>
        /// Método responsável pela criação de um objeto a partir dos controles da pagina
        /// </summary>
        /// <returns></returns>
        protected virtual T ObjectBuild()
        {
            return (T)null;
        }
    }

    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// Id - Identificador de um objeto
        /// </summary>
        protected virtual int? Id
        {
            get
            {
                if (ViewState["_ID"] == null) return null;
                return Convert.ToInt32(ViewState["_ID"]);
            }
            set
            {
                ViewState["_ID"] = value;
            }
        }
        /// <summary>
        /// Método responsável pelo carregamento inicial da pagina
        /// </summary>
        protected virtual void PageLoad()
        {

        }
        /// <summary>
        /// Metodo responsável por limpar os controles da pagina 
        /// </summary>
        protected virtual void PageClear()
        {
            Id = null;
        }
        /// <summary>
        /// Método responsável pelo carregamento dos controles da página 
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void PageFill(Object entity)
        {

        }
        /// <summary>
        /// Método responsável pela criação de um objeto a partir dos controles da pagina
        /// </summary>
        /// <returns></returns>
        protected virtual Object ObjectBuild()
        {
            return null;
        }

        public void Alert(string message)
        {
            Locator.GetComponet<IHandlerMessage>().Show(message);
        }
        public void AlertRedirect(string message, string page)
        {
            string script = string.Format("alert('{0}'); location.href='{1}';", message, page);
            Locator.GetComponet<Alfa.Core.Web.HandlerMessage>().ExecuteScript(script);
        }
        public void ExecuteScript(string script)
        {
            Locator.GetComponet<Alfa.Core.Web.HandlerMessage>().ExecuteScript(script);
        }
    }
}
