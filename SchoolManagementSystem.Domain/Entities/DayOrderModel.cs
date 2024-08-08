using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class DayOrderModel : Base
    {
        public string? DayOrderTitle { get; set; }
        public string? DocumentPath { get; set; }
        public bool HasTable { get; set; }
        public DocumentType DocType { get; set; }
        public Guid IdMetting { get; set; }
        [JsonIgnore]
        public Meeting? Meeting { get; set; }
    }
}
