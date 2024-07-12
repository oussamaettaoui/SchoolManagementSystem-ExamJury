using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class AddMeetingCommandHandler : IRequestHandler<AddMeetingCommand, string>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public AddMeetingCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddMeetingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string result = await _uos.MeetingService.AddMeetingAsync(_mapper.Map<Meeting>(request));
                if (result == "Success")
                {
                    return "the meeting added Successfully";
                }
                return "Error During Adding";
            }
            catch (Exception ex)
            {
                throw new Exception("FaildInAdd handler" + ex.ToString());
            }
        }
    }
}
