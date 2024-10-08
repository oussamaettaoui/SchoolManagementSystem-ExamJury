﻿using MediatR;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;


namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries
{
    public class GetJuryMemberByIdQuery : IRequest<JuryMemberDto>
    {
        public Guid JuryMemberId { get; set; }
        public GetJuryMemberByIdQuery(Guid id)
        {
            JuryMemberId = id;
        }
    }
}