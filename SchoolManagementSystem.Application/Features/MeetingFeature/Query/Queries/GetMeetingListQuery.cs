using MediatR;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Query.Queries
{
    public class GetMeetingListQuery : IRequest<List<MeetingDto>>
    {
    }
}
