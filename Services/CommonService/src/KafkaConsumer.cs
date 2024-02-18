using Confluent.Kafka;
using Fina.Services.CommonService;

public class KafkaConsumer<T> : IKafkaConsumer<T>, IDisposable {
	private IConsumer<string, Record<T>> Consumer { get; set; }
	private Action<ConsumeResult<string, Record<T>>> ConsumerFunction { get; set; }

	public KafkaConsumer(string groupId, string topic, Action<ConsumeResult<string, Record<T>>> consumerFunction, IDictionary<string, string> configurations) {
		Consumer = new ConsumerBuilder<string, Record<T>>(GetConfiguration(groupId, configurations)).Build();
		Consumer.Subscribe(topic);
		ConsumerFunction = consumerFunction;
	}

	public Record<T> Consume() {
		var consumeResult = Consumer.Consume();
		ConsumerFunction.Invoke(consumeResult);
		return consumeResult.Message.Value;
	}

	public void Run() {
		while(true) {

		}
	}

	public ConsumerConfig GetConfiguration(string groupId, IDictionary<string, string> overrideConfig) {
		var config = new ConsumerConfig(overrideConfig) {
			BootstrapServers = "[::1]:9092",
			GroupId = groupId,
		};
		return config;
	}

	public void Dispose() {
		Consumer.Dispose();
	}
}