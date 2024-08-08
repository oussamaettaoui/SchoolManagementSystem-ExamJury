using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/JuryMember")]
    [Authorize(Policy = "DirectorOrAssistantPolicy")]
    [ApiController]
    public class JuryMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JuryMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult>  GetAllJuryMembers()
        {
            List<JuryMemberDto> result = await _mediator.Send(new GetJuryMemberListQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJuryMember([FromRoute] Guid id)
        {
            JuryMemberDto result = await _mediator.Send(new GetJuryMemberByIdQuery(id));
            return Ok(result);
        } 
        [HttpPost]
        public async Task<IActionResult> CreateJuryMember([FromForm] AddJuryMemberCommand command)
        {
            string result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            string result = await _mediator.Send(new DeleteJuryMemberCommand(id));      
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> EditEntreprise([FromForm] EditJuryMemberCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
