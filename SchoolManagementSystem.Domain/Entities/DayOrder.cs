using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class DayOrder : Base
    {
        public string? DayOrderTitle { get; set; }
        public string? DocumentPath { get; set; }
        public bool HasTable { get; set; }
        public DocumentType DocType { get; set; }
    }
}