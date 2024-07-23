namespace SchoolManagementSystem.Domain.Dtos.DayOrderModelDtos
{
    public class AddDayOrderModel
    {
        public Guid DayOrderId { get; set; }
        public string? DayOrderTitle { get; set; }
        public string? DocumentPath { get; set; }
    }
}
