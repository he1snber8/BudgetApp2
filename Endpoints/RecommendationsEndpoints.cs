using Project_Backend_2024.DTO;

namespace Project_Backend_2024.Endpoints;

public static class RecommendationsEndpoints
{
    private static readonly List<Recommendation> _recommendations = new()
    {
        new TechStack { recommendation = "Track expenses for a week" }
    };

    public static void MapRecommendationsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/recommendations");

        group.MapGet("/", () => Results.Ok(_recommendations));

        group.MapPost("/", (Recommendation recommendation) =>
        {
            _recommendations.Add(recommendation);
            return Results.Created($"/recommendations/{_recommendations.Count - 1}", recommendation);
        });
    }
}
