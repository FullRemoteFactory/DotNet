namespace TravelBookingGraphQl.GraphQl
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
