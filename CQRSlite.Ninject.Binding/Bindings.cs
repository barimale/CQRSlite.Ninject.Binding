using CQRSlite.Caching;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Ninject.Bindings.WriteModel.Handlers;
using CQRSlite.Routing;
using Ninject.Modules;

namespace CQRSlite.Ninject.Bindings
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandSender, IEventPublisher, IHandlerRegistrar>()
                .To<Router>()
                .InSingletonScope();

            Bind<ICache>()
                .To<MemoryCache>()
                .InSingletonScope();

            Bind<IRepository>()
                .To<Repository>()
                .InSingletonScope()
                .WithConstructorArgument(typeof(IEventStore));

            Bind<ISession>()
                .To<Session>();

            Helper.BindHandlerBy(typeof(ICommandHandler));

            Kernel.RegisterInAssemblyOf(typeof(ICommandHandler));
        }
    }
}