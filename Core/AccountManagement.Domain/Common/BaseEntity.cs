namespace AccountManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
    }
}
