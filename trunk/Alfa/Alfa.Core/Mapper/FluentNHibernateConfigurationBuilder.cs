using System.Reflection;
using Castle.Core.Configuration;
using Castle.Facilities.NHibernateIntegration;
using Castle.Facilities.NHibernateIntegration.Builders;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Conventions;

namespace Alfa.Core.Mapper
{
    public class FluentNHibernateConfigurationBuilder : IConfigurationBuilder
    {
        public Configuration GetConfiguration(IConfiguration facilityConfiguration)
        {
            var defaultConfigurationBuilder = new DefaultConfigurationBuilder();
            var configuration = defaultConfigurationBuilder.GetConfiguration(facilityConfiguration);
            configuration.AddAutoMappings(CreateAutomappings());

            return configuration;
        }

        protected virtual void ConfigureMapping(AutoPersistenceModel autoPersistenteModel) { }

        private AutoPersistenceModel CreateAutomappings()
        {
            // This is the actual automapping - use AutoMap to start automapping,
            // then pick one of the static methods to specify what to map (in this case
            // all the classes in the assembly that contains Employee), and then either
            // use the Setup and Where methods to restrict that behaviour, or (preferably)
            // supply a configuration instance of your definition to control the automapper.
            // AutoMap.AssemblyOf<Produto>(new AutomappingConfiguration())
            //    .Conventions.Add<CascadeConvention>();

            AutoPersistenceModel autoPersistenceModel = AutoMap.Assembly(AssemblyConfig.GetAssembly(), new AutomappingConfiguration());

            ConfigureMapping(autoPersistenceModel);

            autoPersistenceModel.Conventions.Add<CascadeConvention>();
            autoPersistenceModel.Conventions.Add<ConcorrencyConvention>();
            autoPersistenceModel.Conventions.Add<EnumConvention>();
            autoPersistenceModel.Conventions.Add<NotNullPropertyConvention>();

      
            autoPersistenceModel.OverrideAll(
                m => m.IgnoreProperties( property => property.Name.StartsWith("_")));
       
            //autoPersistenceModel.Conventions.Add(new CascadeConvention(), new ConcorrencyConvention());

            return autoPersistenceModel;
        }

        public static void Create()
        {
            new FluentNHibernateConfigurationBuilder().CreateDatabase();
        }

        public void CreateDatabase()
        {
            Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2005
               .ConnectionString(c => c
               .FromConnectionStringWithKey("connectionString"))
               .Cache(c => c
               .UseQueryCache()
               .ProviderClass<HashtableCacheProvider>())
               .ShowSql())
               .Mappings(m => m
               .AutoMappings.Add(CreateAutomappings()))
               .ExposeConfiguration(BuildSchema)
               .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaUpdate(config).Execute(true, true);
            //new SchemaExport(config)
            //    .Create((true, true);
        }
    }
}