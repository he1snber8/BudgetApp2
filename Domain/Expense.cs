using System;
using Project_Backend_2024.DTO.TechStack;
namespace BudgetApp2.Domain;
public record Expense(Guid Id,string Category,decimal Amount,DateTime Date,string Notes="");
