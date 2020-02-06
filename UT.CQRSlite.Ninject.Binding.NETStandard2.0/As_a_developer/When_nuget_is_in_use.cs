using CQRSlite.Domain;
using CQRSlite.Ninject.Binding;
using Ninject;
using NUnit.Framework;
using UT.CQRSlite.Ninject.Binding.NETCore30.Preconfiguration;

namespace UT.CQRSlite.Ninject.Binding.NETCore3._0
{
    public class When_nuget_is_in_use
    {
        [Test]
        public void I_d_like_to_have_bindings_loaded_correctly()
        {
            //given
            StandardKernel kernel = new StandardKernel(
                new DummyBindings(),
                new Bindings());

            //when
            var library = kernel.Get<ISession>();

            //then
            Assert.IsNotNull(library);
        }
    }
}
