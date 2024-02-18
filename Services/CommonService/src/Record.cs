namespace Fina.Services.CommonService;

public class Record<T> {
	private TrackingId Id { get; set; }
	private T Payload { get; set; }

	public Record(TrackingId id, T payload) {
		Id = id;
		Payload = payload;
	}

	public TrackingId getId() => Id;
	public T getPayload() => Payload;
}