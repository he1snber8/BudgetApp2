namespace BudgetApp2.Services;
public class BudgetService{
  public decimal GetRemaining(decimal income,decimal expenses)=>income-expenses;
}