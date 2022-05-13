using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExploreNationalParks;

namespace ExploreNationalParks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private readonly NationalParkDBContext _context;

        public NationalParksController(NationalParkDBContext context)
        {
            _context = context;
        }

        // GET: returns full list of NationalParks 
        [HttpGet]
        [Route("GetNationalParkList")]
        public async Task<ActionResult<List<NationalPark>>> GetnationalParks()
        {
            List<NationalPark> parkList = new List<NationalPark>();
            parkList = await _context.nationalParks.ToListAsync();

            if (parkList == null)
          {
              return NotFound();
          }
            return Ok(parkList);
        }

        // GET: specific park by id
        [HttpGet]
        [Route("GetParkBy{Id}")]
        public async Task<ActionResult<NationalPark>> GetNationalPark(int id)
        {
            NationalPark park = new NationalPark();
            park = await _context.nationalParks.FindAsync(id);

          if (park == null)
          {
              return NotFound();
          }
          else
          {
                return Ok(park);
          }
        }

        // Get 1 random park
        [HttpGet]
        [Route("GetaRandomPark")]
        public async Task<ActionResult<NationalPark>> GetRandomPark()
        { 
            int parkCount = _context.nationalParks.Count();
            Random randomNum = new Random();

            int randomParkId = randomNum.Next(1, parkCount + 1);

            if (!NationalParkExists(randomParkId))
            {
                return BadRequest();
            }
            else
            {
                NationalPark park = await _context.nationalParks.FindAsync(randomParkId);

                if (park == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(park);
                }
            }
        }

        //TODO: REBUILD WITH TOKENIZATION*****
        [HttpPut]
        [Route("UpdatePark{Id}")]
        public async Task<IActionResult> PutNationalPark(int id, NationalPark nationalPark)
        {
            if (id != nationalPark.ParkID)
            {
                return BadRequest();
            }

            _context.Entry(nationalPark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalParkExists(id))
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

        // POST: api/NationalParks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddaPark")]
        public async Task<ActionResult<NationalPark>> PostNationalPark(NationalPark nationalPark)
        {
          if (_context.nationalParks == null)
          {
              return Problem("Entity set 'NationalParkDBContext.nationalParks'  is null.");
          }
            _context.nationalParks.Add(nationalPark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNationalPark", new { id = nationalPark.ParkID }, nationalPark);
        }

        // DELETE: api/NationalParks/5
        [HttpDelete]
        [Route("DeleteParkBy{Id}")]
        public async Task<IActionResult> DeleteNationalPark(int id)
        {
            if (_context.nationalParks == null)
            {
                return NotFound();
            }
            var nationalPark = await _context.nationalParks.FindAsync(id);
            if (nationalPark == null)
            {
                return NotFound();
            }

            _context.nationalParks.Remove(nationalPark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalParkExists(int id)
        {
            return (_context.nationalParks?.Any(e => e.ParkID == id)).GetValueOrDefault();
        }
    }
}
