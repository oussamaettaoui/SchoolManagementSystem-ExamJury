using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.JuryFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.JuryDtos;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "DirectorOrAssistantPolicy")]
    public class JuryController : ControllerBase
    {
        #region Props
        private readonly IMediator _mediator;
        #endregion
        #region Constructor
        public JuryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetJuryList()
        {
            List<JuryDto> juries = await _mediator.Send(new GetJuryListQuery());
            if(juries == null)
            {
                return BadRequest();
            }
            return Ok(juries);
        }
        #endregion
    }
}
