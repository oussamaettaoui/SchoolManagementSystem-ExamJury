using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "DirectorOrAssistantPolicy")]
    public class JuryMemberRoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JuryMemberRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMeetings()
        {
            List<JuryMemberRoleDto> result = await _mediator.Send(new GetJuryMemberRoleListQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJuryMember([FromRoute] Guid id)
        {
            JuryMemberRoleDto result = await _mediator.Send(new GetJuryMemberRoleByIdQuery(id));
            return Ok(result);
        }
    }
}
