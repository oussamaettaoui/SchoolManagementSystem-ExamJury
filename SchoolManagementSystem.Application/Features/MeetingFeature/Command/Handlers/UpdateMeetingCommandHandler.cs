using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand, string>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public UpdateMeetingCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
        {
            Meeting meeting = await _uos.MeetingService.GetMeetingByIdAsync(request.MeetingId);
            if (meeting == null)
            {
                return "Meetingr Not Found";
            }
            _mapper.Map(request, meeting);
            string result = await _uos.MeetingService.UpdateMeetingAsync(meeting);
            if (result == "Success")
            {
                return "Meeting Updated Successfully";
            }
            return "Error Updating Deleting";
        }
    }
}
