using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.NHibernate
{
    public static class NHibernateExtensions
    {  

        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            
            var configuration = new Configuration()
                .DataBaseIntegration(c =>
                {
                    c.Dialect<MsSql2012Dialect>();
                    c.ConnectionString = connectionString;
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.SchemaAction = SchemaAutoAction.Validate;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });

            configuration.AddMapping(domainMapping);
            var fluentSessionFactory = Fluently
                .Configure(configuration)
                .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Author>())
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();

            var sessionFactory = configuration.BuildSessionFactory();
            services.AddSingleton(fluentSessionFactory);
            services.AddSingleton(factory => fluentSessionFactory.OpenSession());
            services.AddScoped<ISessionManager, SessionManager>();

            return services;
        }
    }
}
