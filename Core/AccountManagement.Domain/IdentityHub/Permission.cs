using AccountManagement.Domain.Common;

namespace AccountManagement.Domain.IdentityHub
{
    public class Permission : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Role : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
