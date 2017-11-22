using DomainModel.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository.Implementation
{

    public class SessionGenerator
    {
        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private SessionGenerator()
        {
        }

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public static SessionGenerator Instance
        {
            get
            {
                return _sessionGenerator;
            }
        }


        private static ISessionFactory CreateSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(
                        builder =>
                            builder.Database("OnlineStoreDB")
                                .Username("sa")
                                .Password("1")
                                .Server("MDDSK40050")
                                .TrustedConnection()))
                                    .Mappings(
                                            x =>
                                            {
                                                x.HbmMappings.AddFromAssembly(typeof(EntityMap<>).Assembly);
                                                x.FluentMappings.AddFromAssembly(typeof(EntityMap<>).Assembly);
                                            })
                                            .ExposeConfiguration(
                                                    cfg => new SchemaUpdate(cfg).Execute(false, true));

            return configuration.BuildSessionFactory();
        }

    }

}
