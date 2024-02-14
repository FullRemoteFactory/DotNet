// ClientsController.cs
Using Microsoft.AspNetCore.Mvc;
Using System.Collections.Generic;
Using System.Linq;
Using TravelAgencyAPI.Models;

Namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    Public Class ClientsController :  ControllerBase
    {
        Private Static List<Client> _clients = New List<Client>()
        {
            New Client { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", DateOfBirth = New System.DateTime(1990, 1, 1) },
            New Client { Id = 2, FirstName = "Jane", LastName = "Doe", Address = "456 Elm St", DateOfBirth = New System.DateTime(1995, 5, 5) }
        };

        [HttpGet("{id}")]
        Public ActionResult<Client> Get(int id)
        {
            var client = _clients.FirstOrDefault(c >= c.Id == id);
            If (client == null)
            {
                Return NotFound();
            }
            Return client;
        }
    }
}
