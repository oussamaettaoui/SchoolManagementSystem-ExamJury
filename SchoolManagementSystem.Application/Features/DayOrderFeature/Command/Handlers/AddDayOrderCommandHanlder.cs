using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Handlers
{
    public class AddDayOrderCommandHanlder : IRequestHandler<AddDayOrderCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public AddDayOrderCommandHanlder(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(AddDayOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result result = await _unitOfService.DayOrderService.AddDayOrderAsync(_mapper.Map<DayOrder>(request));
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
