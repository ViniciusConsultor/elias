using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using System.Configuration;

namespace Alfa.Core.Container
{
    public static class Locator
    {
        private static IWindsorContainer Container;

        static Locator()
        {
            Reset();
        }
        private static void Reset()
        {
            string configFile = ConfigurationManager.AppSettings["CASTLE"];
            if (string.IsNullOrEmpty(configFile))
                Container = new WindsorContainer(new XmlInterpreter());
            else
                Container = new WindsorContainer(new XmlInterpreter(configFile));
            // Container = new WindsorContainer(new XmlInterpreter(@"config\castle.config"));
        }
        public static T GetComponet<T>()
        {
            return Container.Resolve<T>();
        }
    }
}