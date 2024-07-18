using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Handlers
{
    public class DeleteDayOrderCommandHanlder : IRequestHandler<DeleteDayOrderCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public DeleteDayOrderCommandHanlder(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }
        public Task<Result> Handle(DeleteDayOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
