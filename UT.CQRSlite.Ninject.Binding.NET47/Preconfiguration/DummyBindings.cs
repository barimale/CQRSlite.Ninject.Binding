using CQRSlite.Events;
using Ninject.Modules;
using UT.CQRSlite.Ninject.Binding.NET47.Preconfiguration.Mocks;

namespace UT.CQRSlite.Ninject.Binding.NET47.Preconfiguration
{
    public class DummyBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventStore>()
                .To<EventStore>()
                .InSingletonScope();
        }
    }
}