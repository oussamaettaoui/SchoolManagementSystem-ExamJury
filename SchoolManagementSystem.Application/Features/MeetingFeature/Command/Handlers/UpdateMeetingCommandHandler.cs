using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand, Result>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public UpdateMeetingCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Meeting meeting = await _uos.MeetingService.GetMeetingByIdAsync(request.MeetingId);
                if (meeting == null)
                {
                    return Result.NotFound;
                }
                _mapper.Map(request, meeting);
                Result result = await _uos.MeetingService.UpdateMeetingAsync(meeting);
                if (result == Result.Success)
                {
                    return Result.Success;
                }
                return Result.Failure;
            }
            catch (Exception ex)
            {
                throw new Exception("Faild In Add handler" + ex.ToString());
            }
        }
    }
}
