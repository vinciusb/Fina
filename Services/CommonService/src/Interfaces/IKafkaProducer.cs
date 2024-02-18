using Confluent.Kafka;

namespace Fina.Services.CommonService;

public interface IKafkaProducer<T> : IDisposable {
	void Post(string topic, string key, TrackingId id, T item);
	Task<DeliveryResult<string, Record<T>>> PostAsync(string topic, string key, TrackingId id, T item);
}
