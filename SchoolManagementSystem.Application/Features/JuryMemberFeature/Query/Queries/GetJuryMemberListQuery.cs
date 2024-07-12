using MediatR;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries
{
    public class GetJuryMemberListQuery : IRequest<List<JuryMemberDto>>
    {
    }
}