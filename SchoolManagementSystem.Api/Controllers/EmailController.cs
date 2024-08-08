using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.EmailFeature.Command.Commands;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "DirectorOrAssistantPolicy")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] SendEmailCommand command)
        {
            Result result = await _mediator.Send(command);
            if(Result.Success == result)
            {
                return Ok("Email Send Successfully");
            }
            return BadRequest("Email not send");
        }
    }
}
