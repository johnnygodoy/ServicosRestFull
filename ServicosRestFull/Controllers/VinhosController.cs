using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicosRestFull.Models;

namespace ServicosRestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinhosController : ControllerBase
    {
        private readonly MeuBanco _context;

        public VinhosController(MeuBanco context)
        {
            _context = context;
        }

        // GET: api/Vinho
        [HttpGet]
        [Authorize]
        
        public async Task<ActionResult<IEnumerable<Vinho>>> Getvinho()
        {
            return await _context.Vinho.ToListAsync();
        }

        // GET: api/Vinho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vinho>> GetVinhos(int id)
        {
            var vinhos = await _context.Vinho.FindAsync(id);

            if (vinhos == null)
            {
                return NotFound();
            }

            return Ok(vinhos);
        }

        // PUT: api/Vinho/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinhos(int id, Vinho vinhos)
        {
            if (id != vinhos.Cod_vinho)
            {
                return BadRequest();
            }

            _context.Entry(vinhos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinhosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vinho
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vinho>> PostVinhos(Vinho vinhos)
        {
            _context.Vinho.Add(vinhos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinhos", new { id = vinhos.Cod_vinho }, vinhos);
        }

        // DELETE: api/Vinho/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="adm")]
        public async Task<IActionResult> DeleteVinhos(int id)
        {
            var vinhos = await _context.Vinho.FindAsync(id);
            if (vinhos == null)
            {
                return NotFound();
            }

            _context.Vinho.Remove(vinhos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinhosExists(int id)
        {
            return _context.Vinho.Any(e => e.Cod_vinho == id);
        }
    }
}
