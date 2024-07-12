using MediatR;
<<<<<<< HEAD
=======
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
>>>>>>> 12cac6bedaf3967337d569e66dfe177cae7333cc

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
<<<<<<< HEAD
}
=======
}
>>>>>>> 12cac6bedaf3967337d569e66dfe177cae7333cc
