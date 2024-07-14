using MediatR;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;

namespace SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Queries
{
    public class GetJuryMemberRoleListQuery : IRequest<List<JuryMemberRoleDto>>
    {
    }
}
