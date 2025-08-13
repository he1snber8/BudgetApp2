using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.Domain;
public record Expense(System.Guid Id,string Category,decimal Amount,System.DateTime Date,string Notes="");