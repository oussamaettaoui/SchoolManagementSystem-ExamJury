using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.MeetingFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/Meeting")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMeetings()
        {
            List<MeetingDto> result = await _mediator.Send(new GetMeetingListQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJuryMember([FromRoute] Guid id)
        {
            SingleMeetingDto result = await _mediator.Send(new GetMeetingByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody] AddMeetingCommand command)
        {
            Result result = await _mediator.Send(command);
            if (result == Result.Success)
            {
                return Ok("Meeting created successfully");
            }
            return BadRequest("Meeting not created");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMeeting([FromBody] UpdateMeetingCommand command)
        {
            Result res = await _mediator.Send(command);
            if (res == Result.Success)
            {
                return Ok("Meeting updated successfully");
            }
            return BadRequest("Meeting not updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingAsync(Guid id)
        {
            Result res = await _mediator.Send(new DeleteMeetingCommand(id));
            
            if (res == Result.Success)
            {
                return Ok("Meeting Deleted successfully");
            }
            else if (res == Result.NotFound)
            {
                return NotFound("Meeting Not Found");
            }
            return BadRequest("Meeting not updated");
  
        }
    }
}
