using Application.Interfaces.Strategy;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Abstract
{
    public class AssignStrategy : IStrategy
    {
        private List<Developer> _developers;
        private List<Tasks> _tasks;

        public void AssignTasks(List<Developer> developers, List<Tasks> tasks)
        {
            _developers = developers;
            _tasks = tasks.OrderByDescending(t => t.Difficulty).ToList();
        }

        public (List<Developer>, int) CalculateAndPrintPlan()
        {
            int totalWeeks = CalculatePlan();
            return (_developers.Where(dev => dev.Assignments.Any()).ToList(), totalWeeks);
        }

        private int CalculatePlan()
        {
            int currentWeek = 1;
            bool allTasksAssigned = false;

            while (!allTasksAssigned)
            {
                allTasksAssigned = AssignTasksForWeek(currentWeek);
                if (!allTasksAssigned)
                {
                    ResetWorkingHoursForNewWeek();
                    currentWeek++;
                }
            }

            return currentWeek;
        }

        private bool AssignTasksForWeek(int week)
        {
            bool allTasksAssigned = true;

            foreach (var task in _tasks)
            {
                bool assigned = AssignTaskToDeveloper(task, week);
                if (!assigned)
                {
                    allTasksAssigned = false;
                }
            }

            return allTasksAssigned;
        }

        private bool AssignTaskToDeveloper(Tasks task, int week)
        {
            foreach (var dev in _developers.OrderByDescending(d => d.WorkingHours))
            {
                int taskDurationForDev = CalculateTaskDuration(task, dev);
                if (dev.WorkingHours >= taskDurationForDev)
                {
                    dev.Assignments.Add(new TaskAssignment { Task = task, AssignedWeek = week, HoursSpent = taskDurationForDev });
                    dev.WorkingHours -= taskDurationForDev;
                    return true;
                }
            }

            return false;
        }

        private void ResetWorkingHoursForNewWeek()
        {
            _developers.ForEach(d => d.WorkingHours = 45);
        }

        private int CalculateTaskDuration(Tasks task, Developer dev)
        {
            return (task.Duration * task.Difficulty) / dev.Capacity;
        }

    }

}
