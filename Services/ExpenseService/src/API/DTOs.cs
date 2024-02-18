using Fina.Services.ExpenseService.Domain.ExpenseAggregate.ValueObjects;

namespace Fina.Services.ExpenseService.API.DTO;

public record ExpenseDTO(int Value, string Tag, Location Location);