using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Alfa.Core.Mapper
{
    public class AssemblyConfig
    {
        /// <summary>
        /// Recupera o assembly alvo do mapeamento.
        /// Necessário informar no .config, a key "Assembly" cujo value 
        /// será o assembly do modelo
        /// </summary>
        /// <exception cref="System.TypeInitializationException">
        /// </exception>
        /// <returns></returns>
        public static System.Reflection.Assembly GetAssembly()
        {
            return Assembly.Load(
                System.Configuration.ConfigurationManager.AppSettings["ASSEMBLY"]
            );
        }

        public static String Namespace()
        {
            return System.Configuration.ConfigurationManager.AppSettings["NAMESPACE"];
        }
    }
}
