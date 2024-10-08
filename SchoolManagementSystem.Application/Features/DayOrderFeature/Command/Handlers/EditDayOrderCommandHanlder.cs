﻿using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Handlers
{
    public class EditDayOrderCommandHanlder : IRequestHandler<EditDayOrderCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public EditDayOrderCommandHanlder(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(EditDayOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DayOrder dayOrder = await _unitOfService.DayOrderService.GetDayOrderByIdAsync(request.DayOrderId);
                if (dayOrder == null)
                {
                    return Result.NotFound;
                }
                _mapper.Map(request, dayOrder);
                Result result = await _unitOfService.DayOrderService.EditDayOrderAsync(dayOrder,request.DocumentFile);
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
