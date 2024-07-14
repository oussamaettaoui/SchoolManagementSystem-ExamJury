using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.MeetingFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Query.Handlers
{
    public class GetMeetingListQueryHandler : IRequestHandler<GetMeetingListQuery, List<MeetingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfService _unitOfService;
        public GetMeetingListQueryHandler(IMapper mapper, IUnitOfService unitOfService)
        {
            _mapper = mapper;
            _unitOfService = unitOfService;
        }
        public async Task<List<MeetingDto>> Handle(GetMeetingListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Meeting> meetings = await _unitOfService.MeetingService.GetMeetingListAsync();
                return _mapper.Map<List<MeetingDto>>(meetings);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
