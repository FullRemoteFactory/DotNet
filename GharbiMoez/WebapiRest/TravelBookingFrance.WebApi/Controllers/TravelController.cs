using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingFrance.BLL.Features.Travel.Queries.Models;
using TravelBookingFrance.WebApi.Base;

namespace TravelBookingFrance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TravelController : AppControllerBase
    {
        #region CTOR
        private readonly IMediator _mediator;

        public TravelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        [HttpGet("GetAllTravelByCustomerId")]
        public async Task<IActionResult> GetAllTravelByCustomerId([FromQuery] GetTravelListByCustomerId query)
        {
            /*return NewResult(await Mediator.Send(query));*/
            return NewResult(await Mediator.Send(query));
        }
        [HttpGet("GetTravelById")]
        public async Task<IActionResult> GetTravelById([FromQuery] GetTravelById query)
        {
            /*return NewResult(await Mediator.Send(query));*/
            return NewResult(await Mediator.Send(query));
        }

    }
}
