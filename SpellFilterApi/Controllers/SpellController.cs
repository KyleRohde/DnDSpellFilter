using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpellFilter.Models;

namespace SpellFilterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        private readonly SpellFilterContext _context;

        public SpellController(SpellFilterContext context)
        {
            _context = context;
        }

        // GET: api/Spell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spell>>> GetSpells()
        {
          if (_context.Spells == null)
          {
              return NotFound();
          }
            return await _context.Spells.ToListAsync();
        }

        // GET: api/Spell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spell>> GetSpell(Guid id)
        {
          if (_context.Spells == null)
          {
              return NotFound();
          }
            var spell = await _context.Spells.FindAsync(id);

            if (spell == null)
            {
                return NotFound();
            }

            return spell;
        }

        // POST: api/Spell
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spell>> PostSpell(Spell spell)
        {
          if (_context.Spells == null)
          {
              return Problem("Entity set 'SpellFilterContext.Spells'  is null.");
          }
            _context.Spells.Add(spell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpell", new { id = spell.Id }, spell);
        }

        // PUT: api/Spell/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpell(Guid id, Spell spell)
        {
            if (id != spell.Id)
            {
                return BadRequest();
            }

            _context.Entry(spell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpellExists(id))
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

        // DELETE: api/Spell/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpell(Guid id)
        {
            if (_context.Spells == null)
            {
                return NotFound();
            }
            var spell = await _context.Spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }

            _context.Spells.Remove(spell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpellExists(Guid id)
        {
            return (_context.Spells?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
