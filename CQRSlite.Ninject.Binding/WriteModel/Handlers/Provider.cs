using Microsoft.Practices.ServiceLocation;
using System;

namespace CQRSlite.Ninject.Bindings.WriteModel.Handlers
{
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
