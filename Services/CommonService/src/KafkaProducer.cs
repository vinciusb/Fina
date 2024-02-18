using Confluent.Kafka;
using Fina.Services.CommonService;

public class KafkaProducer<T> : IKafkaProducer<T>, IDisposable {
	private IProducer<string, Record<T>> Producer { get; set; }

	public KafkaProducer(IDictionary<string, string> configurations) {
		Producer = new ProducerBuilder<string, Record<T>>(GetConfiguration(configurations)).Build();
	}

	private Message<string, Record<T>> CreateMessage(string key, TrackingId id, T item) {
		var record = new Record<T>(id, item);
		return new Message<string, Record<T>> { Key = key, Value = record };
	}

	public void Post(string topic, string key, TrackingId id, T item) {
		Producer.Produce(topic, CreateMessage(key, id, item));
	}

	public Task<DeliveryResult<string, Record<T>>> PostAsync(string topic, string key, TrackingId id, T item) {
		return Producer.ProduceAsync(topic, CreateMessage(key, id, item));
	}

	public ProducerConfig GetConfiguration(IDictionary<string, string> overrideConfig) {
		var config = new ProducerConfig(overrideConfig) {
			BootstrapServers = "[::1]:9092",
			Acks = Acks.All,
		};
		return config;
	}

	public void Dispose() => Producer.Dispose();
}