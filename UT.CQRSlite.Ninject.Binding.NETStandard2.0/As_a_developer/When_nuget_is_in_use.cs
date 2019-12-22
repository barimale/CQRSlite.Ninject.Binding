using CQRSlite.Domain;
using Ninject;
using NUnit.Framework;

namespace UT.CQRSlite.Ninject.Binding.NETCore3._0
{
    public class When_nuget_is_in_use
    {
        [Test]
        public void I_d_like_to_have_bindings_loaded_correctly()
        {
            //given
            StandardKernel kernel = new StandardKernel(new global::CQRSlite.Ninject.Binding.Bindings());

            //when
            var library = kernel.Get<ISession>();

            //then
            Assert.IsNotNull(library);
        }
    }
}
