using MediatR;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Queries
{
    public class GetJuryMemberRoleByIdQuery : IRequest<JuryMemberRoleDto>
    {
        public Guid JuryMemberRoleId { get; set; }
        public GetJuryMemberRoleByIdQuery(Guid id)
        {
            JuryMemberRoleId = id;
        }
    }
}
