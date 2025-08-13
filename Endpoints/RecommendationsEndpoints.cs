using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.Endpoints;
public static class RecommendationsEndpoints{
  public static void Map(object app){
    TechStack.Map(app,"GET","/recommendations",()=>new[]{"Track dining spend","Auto-transfer savings"});
  }
}