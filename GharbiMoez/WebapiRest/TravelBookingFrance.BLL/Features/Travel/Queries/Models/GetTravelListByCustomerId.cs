using MediatR;
using TravelBookingFrance.BLL.Bases;
using TravelBookingFrance.BLL.Features.Travel.Queries.Response;

namespace TravelBookingFrance.BLL.Features.Travel.Queries.Models
{
    public class GetTravelListByCustomerId : IRequest<Response<IEnumerable<GetTravelListByCustomerIdResponse>>>
    {
        public int CustomerId { get; set; }
    }
}
