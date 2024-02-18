using Confluent.Kafka;
using Fina.Services.CommonService;

namespace Fina.Services.LogService.Domain.LogAggregate;

public class Logger {
	public IKafkaConsumer<string> KafkaConsumer { get; set; }

	public Logger() {
		var consumerGroupName = this.GetType().Name;
		var consumer = new KafkaConsumer<string>(consumerGroupName, "FINA_EXPENSE_LOG", ConsumeLogRecord, new Dictionary<string, string>());
	}

	private void ConsumeLogRecord(ConsumeResult<string, Record<string>> record) {

	}

	public void Run() => KafkaConsumer.Run();
}