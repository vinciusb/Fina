using Confluent.Kafka;
using Fina.Services.CommonService;
using Fina.Services.ExpenseService.Domain.ExpenseAggregate.ValueObjects;

namespace Fina.Services.ExpenseService.Domain.ExpenseAggregate;

public class Expense : Root<Guid> {
	public int Value { get; set; }
	public Tag Tag { get; set; }
	public Location Location { get; set; }

	public Expense(Guid id, int value, Tag tag, Location loc) : base(id) {
		Value = value;
		Tag = tag;
		Location = loc;
	}

	protected override IEnumerable<object> GetAtomic() {
		yield return Value;
		yield return Tag;
		yield return Location;
	}
}