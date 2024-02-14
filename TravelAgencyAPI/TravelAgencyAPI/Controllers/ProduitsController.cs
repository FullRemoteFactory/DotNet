// ProduitsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduitsController : ControllerBase
    {
        private static List<Produit> _produits = new List<Produit>()
        {
            new Produit { Id = 1, Name = "Hotel ABC", Description = "Luxury hotel in Marrakech" }
            // Ajoutez d'autres produits selon les besoins
        };

        [HttpGet("{id}")]
        public ActionResult<Produit> Get(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
            {
                return NotFound();
            }
            return produit;
        }
    }
}
