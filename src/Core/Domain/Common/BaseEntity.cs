namespace Domain.Common
{
    public class BaseEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int ID { get; set; }
    }
}
