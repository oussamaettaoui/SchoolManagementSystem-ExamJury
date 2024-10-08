﻿using SchoolManagementSystem.Domain.Dtos.JuryDtos;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.MeetingDtos
{
    public class MeetingDto
    {
        public Guid MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public JuryDto? Jury { get; set; }
        public Status Status { get; set; }

    }
}
