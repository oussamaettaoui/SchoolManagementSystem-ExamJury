using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.DayOrderModelDtos
{
    public class AddDayOrderModel
    {
        public Guid DayOrderId { get; set; }
        public string? DayOrderTitle { get; set; }
        public string? DocumentPath { get; set; }
        public bool HasTable { get; set; }
        public DocumentType DocType { get; set; }
        public Status Status { get; set; }
    }
}
