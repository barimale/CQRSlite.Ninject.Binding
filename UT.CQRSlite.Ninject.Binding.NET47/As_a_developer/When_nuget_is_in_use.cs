using CQRSlite.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using UT.CQRSlite.Ninject.Binding.NET47.Preconfiguration;

namespace UT.CQRSlite.Ninject.Binding.NET47
{
    [TestClass]
    public class When_nuget_is_in_use
    {
        [TestMethod]
        public void I_d_like_to_have_bindings_loaded_correctly()
        {
            //given

            StandardKernel kernel = new StandardKernel(
                new DummyBindings(), 
                new global::CQRSlite.Ninject.Binding.Bindings());

            //when
            var library = kernel.Get<ISession>();

            //then
            Assert.IsNotNull(library);
        }
    }
}
