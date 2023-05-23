using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlancherExpertWebServices.Models;

namespace PlancherExpertWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly CouvrePlancherDBContext _context;

        public CommandeController(CouvrePlancherDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            return await _context.Commande.ToListAsync();

        }

        [HttpGet("{clientData}")]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande(string ClientData)
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            var commandes = await _context.Commande.Where(item=>item.ClientData==ClientData).ToListAsync();

            if (commandes == null)
            {
                return NotFound();
            }

            return commandes;
        }
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            if (_context.Commande == null)
            {
                return Problem("Entity set 'CouvrePlancherDBContext.CouvrePlancher'  is null.");
            }
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommande), new { id = commande.Id }, commande);
        }

    }
    
}
