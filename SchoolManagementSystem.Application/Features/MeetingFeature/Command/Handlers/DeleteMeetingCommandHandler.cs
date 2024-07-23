using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        public DeleteMeetingCommandHandler(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<Result> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Meeting meeting = await _unitOfService.MeetingService.GetMeetingByIdAsync(request.MeetingId);
                if (meeting == null)
                {
                    return Result.NotFound;
                }
                Result result = await _unitOfService.MeetingService.DeleteMeetingAsync(meeting);
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
                throw new Exception("Faild In Delete handler" + ex.ToString());
            }
        }
    }
}
