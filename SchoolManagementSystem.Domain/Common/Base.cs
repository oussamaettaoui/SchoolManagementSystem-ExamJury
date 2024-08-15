using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Common
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ValidateAt { get; set; }
        public Status Status { get; set; }

    }
}
