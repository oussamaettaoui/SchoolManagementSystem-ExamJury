using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class DayOrder : Base
    {
        public string? DayOrderTitle { get; set; }
        public string? FilePath { get; set; }
    }
}
