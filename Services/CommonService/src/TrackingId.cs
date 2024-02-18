namespace Fina.Services.CommonService;

public sealed class TrackingId {
	private string Id { get; set; }

	public TrackingId(string topic) => Id = $"{topic}({Guid.NewGuid()})";
	public TrackingId StackWith(string newTopic) => new TrackingId($"{Id}->{newTopic}");
}
