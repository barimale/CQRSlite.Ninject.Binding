using CQRSlite.Domain;

namespace CQRSlite.Ninject.Binding.WriteModel.Handlers
{
    public partial class CommandHandlers
    {
        private readonly ISession Session;

        public CommandHandlers(ISession session)
        {
            Session = session;
        }

        //As it is a partial class, please implement new handlers in separated classes.
    }
}