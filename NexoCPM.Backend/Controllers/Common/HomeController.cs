using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NexoCPM.Api.Controllers.Common
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/home")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
