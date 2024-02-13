using MediatR;
using TravelBookingFrance.BLL.Bases;
using TravelBookingFrance.BLL.Features.Product.Queries.Response;

namespace TravelBookingFrance.BLL.Features.Product.Queries.Models
{
    public class GetProductListByTravelId : IRequest<Response<IEnumerable<GetProductListByTravelIdResponse>>>
    {
        public int TravelId { get; set; }
    }
}
