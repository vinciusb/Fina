using Confluent.Kafka;
using Fina.Services.CommonService;
using Fina.Services.ExpenseService.API.DTO;
using Fina.Services.ExpenseService.API.Extensions;
using Fina.Services.ExpenseService.Domain.ExpenseAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Services.ExpenseService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase {
	private readonly ILogger<ExpenseController> _logger;
	// private readonly KafkaProducer<Expense> LogProducer;
	private readonly IKafkaProducer<string> LogProducer;

	public ExpenseController(ILogger<ExpenseController> logger) {
		_logger = logger;
		LogProducer = new KafkaProducer<string>(
			new Dictionary<string, string>() { { "acks", $"{(int)Acks.All}" } }
		);
	}

	// [HttpGet]
	// public async Task<IEnumerable<Expense>> GetExpenses() {
	// }

	[HttpPost]
	public async Task PostExpenses([FromBody] IEnumerable<ExpenseDTO> expenses) {
		// Creates a topic
		var createdExpenses = expenses.Select(ex => ex.AsExpense());

		foreach(var expense in createdExpenses) {
			var id = new TrackingId("CreateExpense");
			// Logs the topics
			// LogProducer.PostAsync("FINA_EXPENSE_LOG", $"{expense.Value}{expense.Tag.Label}", id, expense);
			LogProducer.PostAsync("FINA_EXPENSE_LOG", $"{expense.Value}{expense.Tag.Label}", id, "EMAILLLLLLLLL");
		}
	}
}