using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

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
            Result result = await _mediator.Send(command);
            if (result == Result.Success)
            {
                return Ok("JuryMember created successfully");
            }
            return BadRequest("JuryMember not created");
        }
        [HttpPut]
        public async Task<IActionResult> EditJuryMember([FromForm] EditJuryMemberCommand command)
        {
            Result res = await _mediator.Send(command);
            if (res == Result.Success)
            {
                return Ok("JuryMember updated successfully");
            }
            return BadRequest("JuryMember not updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuryMember(Guid id)
        {
            Result result = await _mediator.Send(new DeleteJuryMemberCommand(id));      
            if (result == Result.Success)
            {
                return Ok("JuryMember Deleted successfully");
            }
            else if (result == Result.NotFound)
            {
                return NotFound("JuryMember Not Found");
            }
            return BadRequest("JuryMember Not Deleted");
        }
        [Authorize(Roles = "director")]
        [HttpPost("/ValidateJuryMember/{id}")]
        public async Task<IActionResult> ValidateJuryMember(Guid id)
        {
            Result result = await _mediator.Send(new ValidateJuryMemberCommand(id));
            if (result == Result.Success)
            {
                return Ok("JuryMember validated successfully");
            }
            return BadRequest("JuryMember not validated");
        }

    }
}
