using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Handlers
{
    public class GetDayOrderListQueryHandler : IRequestHandler<GetDayOrderListQuery, List<DayOrderDto>>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public GetDayOrderListQueryHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }
        public async Task<List<DayOrderDto>> Handle(GetDayOrderListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<DayOrder> dayOrders  = await _uos.DayOrderService.GetDayOrderListAsync();
                return _mapper.Map<List<DayOrderDto>>(dayOrders);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Handler");
            }
        }

    }
}
