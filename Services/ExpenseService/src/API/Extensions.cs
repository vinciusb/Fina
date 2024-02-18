using Fina.Services.ExpenseService.API.DTO;
using Fina.Services.ExpenseService.Domain.ExpenseAggregate;
using Fina.Services.ExpenseService.Domain.ExpenseAggregate.ValueObjects;

namespace Fina.Services.ExpenseService.API.Extensions;

public static class Extensions {
	// User
	public static Expense AsExpense(this ExpenseDTO user) {
		return new Expense(Guid.NewGuid(),
						   user.Value,
						   new Tag(user.Tag),
						   user.Location);
	}
}