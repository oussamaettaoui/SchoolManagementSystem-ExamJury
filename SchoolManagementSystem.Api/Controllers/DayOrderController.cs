using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
