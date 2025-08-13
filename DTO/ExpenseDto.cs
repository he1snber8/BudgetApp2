using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.DTO;

public class Expense {
  public int Id { get;set;}
  public decimal Amount { get;set;}
  public Date TransactionDate { get;set;}
  public string Merchant { get;set;}
}
