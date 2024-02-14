using MediatR;
using TravelBookingFrance.BLL.Bases;
using TravelBookingFrance.BLL.Features.Travel.Queries.Response;

namespace TravelBookingFrance.BLL.Features.Travel.Queries.Models
{
    public class GetTravelById : IRequest<Response<GetTravelListByCustomerIdResponse>>
    {
        public int TravelId { get; set; }
    }
}
