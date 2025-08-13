using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.Services;
public static class ServiceRegistration{
  public static void AddBudgetServices(object services){
    TechStack.Register(services,new BudgetService());
    TechStack.Register(services,new RecommendationService());
  }
}