using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class DayOrderModel : Base
    {
        public string? DayOrderTitle { get; set; }
        public string? DocumentPath { get; set; }
        public Guid IdMetting { get; set; }
        [JsonIgnore]
        public Meeting? Meeting { get; set; }
    }
}
