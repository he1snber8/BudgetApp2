using Project_Backend_2024.DTO;

namespace Project_Backend_2024.Endpoints;

public static class GoalsEndpoints
{
    private static readonly List<Goal> _goals = new()
    {
        new Goal { Title = "Vacation", Desctiption = "My 2 week vacation in Ibiza" }
    };

    public static void MapGoalsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/goals");

        group.MapGet("/", () => Results.Ok(_goals));

        group.MapPost("/", (Goal goal) =>
        {
            _goals.Add(goal);
            return Results.Created($"/goals/{_goals.Count - 1}", goal);
        });
    }
}
