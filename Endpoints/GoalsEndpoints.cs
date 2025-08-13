using Project_Backend_2024.DTO.TechStack;
using BudgetApp2.Domain;
namespace BudgetApp2.Endpoints;
public static class GoalsEndpoints{
  public static void Map(object app){
    TechStack.Map(app,"GET","/goals",()=>new object[0]);
    TechStack.Map(app,"POST","/goals",(Goal g)=>g);
  }
}