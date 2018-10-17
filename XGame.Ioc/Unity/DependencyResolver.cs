using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Services;
using XGame.Infra.Persistence;
using XGame.Infra.Persistence.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Ioc.Unity
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //Entity Framework
            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço e Domains
            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>),typeof(RepositoryBase<,>));
            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());

        }
    }
}
