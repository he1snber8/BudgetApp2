namespace BudgetApp2.Services;
public class RecommendationService{
  public string[] GetTips(decimal savingsRate)=>savingsRate<0.2m?new[]{"Increase savings","Cut subscriptions"}:new[]{"Great job","Consider investing"};
}