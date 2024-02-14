using Microsoft.AspNetCore.Mvc;
using HotChocolate.AspNetCore;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class GraphQLController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public GraphQLController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GraphQLRequest request)
        {
            return Ok(_queryExecutor.Execute(request.Query));
        }
    }
}
