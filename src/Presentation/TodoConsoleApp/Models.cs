using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsoleApp
{
    public class RootObject
    {
        public List<DeveloperReport> DeveloperReport { get; set; }
        public int TotalWeeksReport { get; set; }
    }

    public class DeveloperReport
    {
        public string DeveloperName { get; set; }
        public int Capacity { get; set; }
        public int WorkingHours { get; set; }
        public List<Assignment> Assignments { get; set; }
        public int Id { get; set; }
    }

    public class Assignment
    {
        public Tasks Task { get; set; }
        public int AssignedWeek { get; set; }
        public int HoursSpent { get; set; }
    }

    public class Tasks
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public int DeveloperId { get; set; }
        public int Id { get; set; }
    }

    public class TableDto
    {
        [DisplayName("Geliştirici")]
        public string DeveloperName { get; set; }
        public int AssignedWeek { get; set; }
        public string TaskName { get; set; }
        public int HoursSpent { get; set; }
    }
}
