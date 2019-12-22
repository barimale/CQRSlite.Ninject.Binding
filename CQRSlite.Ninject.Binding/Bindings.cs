using CommonServiceLocator.NinjectAdapter.Unofficial;
using CQRSlite.Domain;
using CQRSlite.Messages;
using CQRSlite.Ninject.Binding.WriteModel.Handlers;
using CQRSlite.Routing;
using Microsoft.Practices.ServiceLocation;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using System;
using System.Linq;
using System.Reflection;

namespace CQRSlite.Ninject.Binding
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISession>()
                .To<Session>();

            Kernel.Bind(x =>
            {
                x.From(
                    typeof(ICommandHandlers).GetTypeInfo().Assembly)
                    .SelectAllClasses()
                    .Where(p =>
                    {
                        var allInterfaces = p.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>));
                    })
                .BindToSelf();
            });

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));

            var registerer = new RouteRegistrar(new Provider(new NinjectServiceLocator(Kernel)));
            registerer.RegisterInAssemblyOf(
                typeof(ICommandHandlers));
        }

        public class Provider : IServiceProvider
        {
            private readonly IServiceLocator _serviceProvider;

            public Provider(IServiceLocator serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public object GetService(Type serviceType)
            {
                return _serviceProvider.GetService(serviceType);
            }
        }
    }
}
