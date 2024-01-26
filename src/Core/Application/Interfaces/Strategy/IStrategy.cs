using Domain.Entities;

namespace Application.Interfaces.Strategy
{
    public interface IStrategy
    {
        void AssignTasks(List<Developer> developers, List<Tasks> tasks);
        (List<Developer>, int) CalculateAndPrintPlan();
    }
}
