using Fina.Services.CommonService;

namespace Fina.Services.ExpenseService.Domain.ExpenseAggregate.ValueObjects;

public class Location : ValueObject {
	public string Country { get; private set; } = null!;
	public string City { get; private set; } = null!;
	public string Street { get; private set; } = null!;
	public int Number { get; private set; }

	public Location(string country, string city, string street, int number) {
		Country = country;
		City = city;
		Street = street;
		Number = number;
	}

	protected override IEnumerable<object> GetAtomic() {
		yield return Country;
		yield return City;
		yield return Street;
		yield return Number;
	}
}