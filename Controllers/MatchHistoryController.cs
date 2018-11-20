using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_MatchHistory.Models;

namespace API_MatchHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchHistoryController : ControllerBase
    {
        private readonly MatchHistoryContext _context;

        public MatchHistoryController(MatchHistoryContext context)
        {
            _context = context;
        }

        // GET: api/MatchHistory
        [HttpGet]
        public IEnumerable<MatchHistoryItem> GetMatchHistoryItem()
        {
            return _context.MatchHistoryItem;
        }

        // GET: api/MatchHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchHistoryItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchHistoryItem = await _context.MatchHistoryItem.FindAsync(id);

            if (matchHistoryItem == null)
            {
                return NotFound();
            }

            return Ok(matchHistoryItem);
        }

        // PUT: api/MatchHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchHistoryItem([FromRoute] int id, [FromBody] MatchHistoryItem matchHistoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matchHistoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(matchHistoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchHistoryItemExists(id))
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

        // POST: api/MatchHistory
        [HttpPost]
        public async Task<IActionResult> PostMatchHistoryItem([FromBody] MatchHistoryItem matchHistoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MatchHistoryItem.Add(matchHistoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchHistoryItem", new { id = matchHistoryItem.Id }, matchHistoryItem);
        }

        // DELETE: api/MatchHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchHistoryItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchHistoryItem = await _context.MatchHistoryItem.FindAsync(id);
            if (matchHistoryItem == null)
            {
                return NotFound();
            }

            _context.MatchHistoryItem.Remove(matchHistoryItem);
            await _context.SaveChangesAsync();

            return Ok(matchHistoryItem);
        }

        private bool MatchHistoryItemExists(int id)
        {
            return _context.MatchHistoryItem.Any(e => e.Id == id);
        }

        // GET: api/Meme/search
        [Route("search/{parameter}")]
        [HttpGet]
        public async Task<List<MatchHistoryItem>> GetSearch([FromRoute] string parameter)
        {
            var memes = (from m in _context.MatchHistoryItem
                         where (m.Home.Contains(parameter) || m.Opposition.Contains(parameter))
                         select m);

            var returned = await memes.ToListAsync();

            return returned;
        }

    }
}