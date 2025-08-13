using Project_Backend_2024.DTO;

namespace Project_Backend_2024.Endpoints;

public static class ExpensesEndpoints
{
    private static readonly List<Expense> _expenses = new()
    {
        new Expense { Id = "123", Amount: 100, Date: DateTime.Now },
        new Expense { Id = "123", Amount: 70, Date: DateTime.Now }
    };

    public static void MapExpensesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/expenses");

        group.MapGet("/", () => Results.Ok(_expenses));

        group.MapPost("/", (TechStack expense) =>
        {
            _expenses.Add(expense);
            return Results.Created($"/expenses/{_expenses.Count - 1}", expense);
        });
    }
}
