using Project_Backend_2024.DTO.TechStack;
using BudgetApp2.DTO;
namespace BudgetApp2.Endpoints;
public static class ExpensesEndpoints{
  public static void Map(object app){
    TechStack.Map(app,"GET","/expenses",()=>new object[0]);
    TechStack.Map(app,"POST","/expenses",(ExpenseDto dto)=>dto);
  }
}