using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class AddMeetingCommandHandler : IRequestHandler<AddMeetingCommand, Result>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public AddMeetingCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddMeetingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result result = await _uos.MeetingService.AddMeetingAsync(_mapper.Map<Meeting>(request));
                if (result == Result.Success)
                {
                    return Result.Success;
                }
                else
                {
                    return Result.Failure;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Faild In Add handler" + ex.ToString());
            }
        }
    }
}
