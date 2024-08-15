using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Handlers
{
    public class ValidateMeetingCommandHandler : IRequestHandler<ValidateMeetingCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;

        public ValidateMeetingCommandHandler(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }

        public async Task<Result> Handle(ValidateMeetingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Meeting meeting = await _unitOfService.MeetingService.GetMeetingByIdAsync(request.MeetingId);
                if (meeting == null)
                {
                    return Result.NotFound;
                }
                Result result = await _unitOfService.MeetingService.ValidateMeetingAsync(meeting);
                if (result == Result.Success)
                {
                    return Result.Success;
                }
                return Result.Failure;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Handler : {ex.ToString()}");
            }
        }
    }
}
