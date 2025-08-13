namespace BudgetApp2.Domain;
public record Goal(System.Guid Id,string Name,decimal TargetAmount,decimal CurrentAmount,System.DateTime TargetDate);