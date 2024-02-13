using AutoMapper;
using MediatR;
using TravelBookingFrance.BLL.Bases;
using TravelBookingFrance.BLL.Features.Product.Queries.Models;
using TravelBookingFrance.BLL.Features.Product.Queries.Response;
using TravelFrance.Services.IServices;

namespace TravelBookingFrance.BLL.Features.Product.Queries.Handlers
{
    public class ProductHandler : ResponseHandler, IRequestHandler<GetProductListByTravelId, Response<IEnumerable<GetProductListByTravelIdResponse>>>
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetProductListByTravelIdResponse>>> Handle(GetProductListByTravelId request, CancellationToken cancellationToken)
        {
            var Result = await _productService.GetAllProductByTravelIdService(request.TravelId);
            var resultMap = _mapper.Map<IEnumerable<GetProductListByTravelIdResponse>>(Result);
            return Success(resultMap);
        }
    }
}
