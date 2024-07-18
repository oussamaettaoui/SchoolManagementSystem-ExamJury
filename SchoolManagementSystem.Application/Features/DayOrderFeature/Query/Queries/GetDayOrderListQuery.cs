using MediatR;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries
{
    public class GetDayOrderListQuery : IRequest<List<DayOrderDto>>
    {
    }
}
