using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Query.Handlers
{
    public class GetMeetingByIdQueryHandler : IRequestHandler<GetMeetingByIdQuery, MeetingDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfService _unitOfService;
        public GetMeetingByIdQueryHandler(IMapper mapper,IUnitOfService unitOfService)
        {
            _mapper = mapper;
            _unitOfService = unitOfService;
        }
        public async Task<MeetingDto> Handle(GetMeetingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Meeting meeting = await _unitOfService.MeetingService.GetMeetingByIdAsync(request.MeetingId);
                return _mapper.Map<MeetingDto>(meeting);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
