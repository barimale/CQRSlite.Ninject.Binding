using CQRSlite.Caching;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Ninject.Binding.WriteModel.Handlers;
using CQRSlite.Routing;
using CQRSlite.Snapshotting;
using Ninject.Modules;

namespace CQRSlite.Ninject.Binding
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
                .WhenInjectedExactlyInto(typeof(SnapshotRepository))
                .InSingletonScope();

            Bind<IRepository>()
                .To<SnapshotRepository>()
                .WithConstructorArgument(typeof(ISnapshotStore))
                .WithConstructorArgument(typeof(ISnapshotStrategy))
                .WithConstructorArgument(typeof(IRepository))
                .WithConstructorArgument(typeof(IEventStore));

            Bind<ISession>()
                .To<Session>();

            Helper.BindHandlerBy(typeof(ICommandHandler));

            Kernel.RegisterInAssemblyOf(typeof(ICommandHandler));
        }
    }
}