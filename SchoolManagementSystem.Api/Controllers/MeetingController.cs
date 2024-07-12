using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromForm] AddMeetingCommand command)
        {
            string result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("/update")]
        public async Task<IActionResult> UpdateMeeting([FromForm] UpdateMeetingCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
