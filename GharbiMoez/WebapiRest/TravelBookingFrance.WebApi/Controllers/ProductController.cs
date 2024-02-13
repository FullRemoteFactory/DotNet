using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingFrance.BLL.Features.Product.Queries.Models;
using TravelBookingFrance.WebApi.Base;

namespace TravelBookingFrance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : AppControllerBase
    {
        #region CTOR
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        [HttpGet("GetAllProductByTravelId")]
        public async Task<IActionResult> GetAllProductByTravelId([FromQuery] GetProductListByTravelId query)
        {
            return NewResult(await Mediator.Send(query));
        }

    }
}
