using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Alfa.Core.Exception;

namespace Alfa.Core.AOP
{
    internal class FactoryHandlerException
    {
        public static IHandlerException Create()
        {
            string ENVIRONMENT = "ENVIRONMENT";
            switch (ConfigurationManager.AppSettings[ENVIRONMENT])
            {
                case "WEB": return new DefaultHandlerException(new Alfa.Core.Web.HandlerMessage());
                case "WINDOWS": return new DefaultHandlerException(new Alfa.Core.Windows.HandlerMessage());
                default: return DefaultHandlerException.Instance;
            }
        }
    }
}
