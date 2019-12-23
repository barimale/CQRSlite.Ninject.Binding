using CommonServiceLocator.NinjectAdapter.Unofficial;
using CQRSlite.Messages;
using CQRSlite.Routing;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Extensions.Conventions.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace CQRSlite.Ninject.Binding.WriteModel.Handlers
{
    public static class Helper
    {
        public static Action<IFromSyntax> BindHandlerBy(Type type)
        {
            return (x) =>
            {
                x.From(
                    type.GetTypeInfo().Assembly)
                    .SelectAllClasses()
                    .Where(p =>
                    {
                        var allInterfaces = p.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>));
                    })
                .BindToSelf();
            };
        }

        public static void RegisterInAssemblyOf(this IKernel Kernel, Type type)
        {
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));

            var registerer = new RouteRegistrar(new Provider(new NinjectServiceLocator(Kernel)));
            registerer.RegisterInAssemblyOf(
                type);
        }
    }
}
