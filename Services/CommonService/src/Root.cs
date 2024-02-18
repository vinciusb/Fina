namespace Fina.Services.CommonService;

public abstract class Root<T> {
	public T Id { get; set; }

	public Root(T id) {
		Id = id;
	}

	protected abstract IEnumerable<object> GetAtomic();
}