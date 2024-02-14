using AutoMapper;
using MediatR;
using TravelBookingFrance.BLL.Bases;
using TravelBookingFrance.BLL.Features.Travel.Queries.Models;
using TravelBookingFrance.BLL.Features.Travel.Queries.Response;
using TravelFrance.Services.IServices;

namespace TravelBookingFrance.BLL.Features.Travel.Queries.Handlers
{
    public class TravelHandler : ResponseHandler, IRequestHandler<GetTravelListByCustomerId, Response<IEnumerable<GetTravelListByCustomerIdResponse>>>,
                                                  IRequestHandler<GetTravelById, Response<GetTravelListByCustomerIdResponse>>
    {
        private ITravelService _TravelService;
        private IMapper _mapper;

        public TravelHandler(ITravelService TravelService, IMapper mapper)
        {
            _TravelService = TravelService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetTravelListByCustomerIdResponse>>> Handle(GetTravelListByCustomerId request, CancellationToken cancellationToken)
        {
            var Result = await _TravelService.GetAllTravelByCustomerIdService(request.CustomerId);
            var resultMap = _mapper.Map<IEnumerable<GetTravelListByCustomerIdResponse>>(Result);
            return Success(resultMap);
        }

        public async Task<Response<GetTravelListByCustomerIdResponse>> Handle(GetTravelById request, CancellationToken cancellationToken)
        {
            var Result = await _TravelService.GetTravelByIdService(request.TravelId);
            var resultMap = _mapper.Map<GetTravelListByCustomerIdResponse>(Result);
            return Success(resultMap);
        }
    }
}
