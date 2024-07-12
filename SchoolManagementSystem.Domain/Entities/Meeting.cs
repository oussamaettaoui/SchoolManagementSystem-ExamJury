using SchoolManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Meeting : Base
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
            public DateTime time { get; set; }
            public string location { get; set; }
            public MeetingType type { get; set; }
            public Guid JuryId { get; set; }
            public Jury? Jury { get; set; }
    }
}
