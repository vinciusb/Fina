using Confluent.Kafka;

namespace Fina.Services.CommonService;

public interface IKafkaConsumer<T> : IDisposable {
	Record<T> Consume();
	void Run();
	ConsumerConfig GetConfiguration(string groupId, IDictionary<string, string> overrideConfig);
}
