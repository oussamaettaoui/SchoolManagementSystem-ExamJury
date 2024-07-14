using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.JuryDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryFeature.Query.Handlers
{
    public class GetJuryListQueryHandler : IRequestHandler<GetJuryListQuery, List<JuryDto>>
    {
        #region Props
        private readonly IMapper _mapper;
        private readonly IUnitOfService _unitOfService;
        #endregion
        #region Constructor
        public GetJuryListQueryHandler(IMapper mapper, IUnitOfService unitOfService)
        {
            _mapper = mapper;
            _unitOfService = unitOfService;
        }
        #endregion
        #region Methods
        public async Task<List<JuryDto>> Handle(GetJuryListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Jury> Juries = await _unitOfService.JuryService.GetJuryListAsync();
                return _mapper.Map<List<JuryDto>>(Juries);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion
    }
}
