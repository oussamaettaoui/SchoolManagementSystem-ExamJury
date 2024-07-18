using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.EmailFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.EmailDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.EmailFeature.Command.Handlers
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public SendEmailCommandHandler(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            _unitOfService.EmailService.SendEmailAsync(_mapper.Map<EmailDto>(request));
            return Result.Success;
        }
    }
}
