using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/JuryMember")]
    [ApiController]
    public class JuryMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JuryMemberController(IMediator mediator)
        {
            _mediator = mediator;
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
        [HttpPut("/edit")]
        public async Task<IActionResult> EditEntreprise([FromForm] EditJuryMemberCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
