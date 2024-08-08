using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "DirectorOrAssistantPolicy")]
    public class DayOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DayOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDayOrders()
        {
            List<DayOrderDto> result = await _mediator.Send(new GetDayOrderListQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDayByIdOrder([FromRoute] Guid id)
        {
            DayOrderDto result = await _mediator.Send(new GetDayOrderByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDayOrder([FromForm] AddDayOrderCommand command)
        {
            Result result = await _mediator.Send(command);
            if (result == Result.Success)
            {
                return Ok("DayOrder created successfully");
            }
            return BadRequest("DayOrder not created");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayOrder(Guid id)
        {
            Result res = await _mediator.Send(new DeleteDayOrderCommand(id));
            if (res == Result.Success)
            {
                return Ok("DayOrder Deleted successfully");
            }
            else if (res == Result.NotFound)
            {
                return NotFound("DayOrder Not Found");
            }
            return BadRequest("DayOrder Not Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDayOrder([FromForm] EditDayOrderCommand command)
        {
            Result res = await _mediator.Send(command);
            if (res == Result.Success)
            {
                return Ok("DayOrder updated successfully");
            }
            else if(res == Result.NotFound)
            {
                return NotFound("DayOrder Not Found");
            }
            return BadRequest("DayOrder not updated");
        }
    }
}
