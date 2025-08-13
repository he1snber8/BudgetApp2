using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.DTO;

public record ExpenseDto(string Category, decimal Amount, DateTime Date, string Notes="");
