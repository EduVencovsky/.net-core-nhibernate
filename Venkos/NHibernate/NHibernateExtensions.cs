using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Book>())
                .BuildSessionFactory();

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(fluentSessionFactory);
            services.AddScoped(factory => fluentSessionFactory.OpenSession());
            services.AddScoped<ISessionManager, SessionManager>();

            return services;
        }
    }
}
