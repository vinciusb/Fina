using Fina.Services.CommonService;

namespace Fina.Services.ExpenseService.Domain.ExpenseAggregate.ValueObjects;

public class Tag : ValueObject {
	public string Label { get; private set; }

	public Tag(string label) {
		Label = label;
	}

	protected override IEnumerable<object> GetAtomic() {
		yield return Label;
	}
}