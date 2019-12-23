# CQRSlite.Ninject.Binding
Some default bindings for: 
```
https://github.com/gautema/CQRSlite
```

## Example of usage
Let's assume that NEventstore is used together with the CQRSlite package.
According to this, as a first step, some bindings have to be added in regular way:

```
Bind<IStoreEvents, ISnapshotStore, ISnapshotManager>()
	.To<SnapshotStore>()
	.InSingletonScope();

Bind<IEventStore>()
	.To<EventStore>()
	.InSingletonScope();
```

Then, as a next step, CQRSlite.Ninject.Bindings.Binding has to be invoked as follows:
```
public class Bindings : CQRSlite.Ninject.Binding.Bindings
{
	public override void Load()
	{
		...

		base.Load();
	}
}
```
.
