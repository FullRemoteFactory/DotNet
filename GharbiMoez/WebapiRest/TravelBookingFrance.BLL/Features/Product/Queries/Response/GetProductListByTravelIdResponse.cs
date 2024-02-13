namespace TravelBookingFrance.BLL.Features.Product.Queries.Response
{
    public class GetProductListByTravelIdResponse
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public ICollection<string> Photos { get; set; }


    }
}
