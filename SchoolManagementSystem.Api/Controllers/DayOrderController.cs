using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Query.Queries;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetDayOrder([FromRoute] Guid id)
        {
            DayOrderDto result = await _mediator.Send(new GetDayOrderByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDayOrder([FromForm] AddDayOrderCommand command)
        {
            Result result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Result result = await _mediator.Send(new DeleteDayOrderCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDayOrder([FromForm] EditDayOrderCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }


    }
}
