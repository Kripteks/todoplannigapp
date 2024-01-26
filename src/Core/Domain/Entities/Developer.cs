using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Developer : BaseEntity
    {
        public string DeveloperName { get; set; }
        public int Capacity { get; set; }
        [NotMapped]
        public int WorkingHours { get; set; } = 45;
        [NotMapped]
        public List<TaskAssignment> Assignments { get; set; } = new List<TaskAssignment>();

    }

    public class TaskAssignment
    {
        public Tasks Task { get; set; }
        public int AssignedWeek { get; set; }
        public int HoursSpent { get; set; }
    }
}
