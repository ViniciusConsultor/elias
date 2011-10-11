using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alfa.Core.Unit;
using Alfa.Core.Container;

namespace Alfa.Core.Web
{
    public class SessionModule : IHttpModule
    {
        //private ITransaction _session;
        private IUnitOfWork _session;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OpenSession);
            context.EndRequest += new EventHandler(CloseSession);
            context.Error += new EventHandler(context_Error);
        }

        private void context_Error(object sender, EventArgs e)
        {
            _session.Rollback();
        }

        private void OpenSession(object sender, EventArgs e)
        {
            _session = Locator.GetComponet<IUnitOfWork>();
            _session.BeginTransaction();
        }

        private void CloseSession(object sender, EventArgs e)
        {
            //_session.Flush();
            _session.Commit();
        }

        public void Dispose()
        {
            _session = null;
        }
    }
}
