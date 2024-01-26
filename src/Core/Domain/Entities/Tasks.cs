using Domain.Common;

namespace Domain.Entities
{
    public class Tasks : BaseEntity
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public int DeveloperId { get; set; }
    }
}
