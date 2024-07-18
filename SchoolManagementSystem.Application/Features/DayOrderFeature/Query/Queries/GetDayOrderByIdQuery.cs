using MediatR;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries
{
    public class GetDayOrderByIdQuery : IRequest<DayOrderDto>
    {
        public Guid DayOrderId { get; set; }
        public GetDayOrderByIdQuery(Guid id)
        {
            DayOrderId = id;
        }
    }
}
