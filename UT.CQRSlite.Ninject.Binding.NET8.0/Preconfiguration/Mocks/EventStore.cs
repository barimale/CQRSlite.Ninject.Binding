using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UT.CQRSlite.Ninject.Binding.net80.Preconfiguration.Mocks
{
    public class EventStore : IEventStore
    {
        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
