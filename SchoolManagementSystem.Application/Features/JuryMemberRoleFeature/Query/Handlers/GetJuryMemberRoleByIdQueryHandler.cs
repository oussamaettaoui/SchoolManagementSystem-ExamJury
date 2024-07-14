using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Handlers
{
    public class GetJuryMemberRoleByIdQueryHandler : IRequestHandler<GetJuryMemberRoleByIdQuery, JuryMemberRoleDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfService _unitOfService;
        public GetJuryMemberRoleByIdQueryHandler(IMapper mapper, IUnitOfService unitOfService)
        {
            _mapper = mapper;
            _unitOfService = unitOfService;
        }

        public async Task<JuryMemberRoleDto> Handle(GetJuryMemberRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMemberRole role = await _unitOfService.JuryMemberRoleService.GetJuryMemberRoleByIdAsync(request.JuryMemberRoleId);
                return _mapper.Map<JuryMemberRoleDto>(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
