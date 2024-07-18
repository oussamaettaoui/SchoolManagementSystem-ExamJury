using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Handlers
{
    public class GetDayOrderByIdQueryHandler : IRequestHandler<GetDayOrderByIdQuery, DayOrderDto>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public GetDayOrderByIdQueryHandler(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }


        public async Task<DayOrderDto> Handle(GetDayOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DayOrder dayOrder = await _unitOfService.DayOrderService.GetDayOrderByIdAsync(request.DayOrderId);
                return _mapper.Map<DayOrderDto>(dayOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Handler : " + ex.ToString());
            }

        }
    }
}
