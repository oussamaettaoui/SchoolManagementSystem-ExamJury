using MediatR;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Query.Queries
{
    public class GetMeetingByIdQuery : IRequest<SingleMeetingDto>
    {
        public Guid MeetingId { get; set; }
        public GetMeetingByIdQuery(Guid id)
        {
            MeetingId = id;
        }
    }
}
