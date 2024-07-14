using MediatR;
using SchoolManagementSystem.Domain.Dtos.JuryDtos;

namespace SchoolManagementSystem.Application.Features.JuryFeature.Query.Queries
{
    public class GetJuryListQuery : IRequest<List<JuryDto>>
    {
    }
}
