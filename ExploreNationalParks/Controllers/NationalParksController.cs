using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExploreNationalParks;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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

        // Adds a park to the database
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        [Route("AddaPark")]
        public async Task<ActionResult<NationalPark>> AddNationalPark(string title, string description, decimal acres, decimal km2, decimal latitude, decimal longitude, DateTime dateEstablished, string imageURL, string npsLink, string state, decimal visitors)
        {
            

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description) && acres != 0 && km2 != 0 && latitude != 0 && longitude != 0 && !string.IsNullOrEmpty(dateEstablished.ToString()) && !string.IsNullOrEmpty(imageURL) && !string.IsNullOrEmpty(npsLink) && !string.IsNullOrEmpty(state) && visitors != 0)
            {
                
                NationalPark n = new NationalPark();

                n.ParkID = 0; // will cause auto increment
                n.Title = title;
                n.Description = description;
                n.Acres = acres;
                n.Km2 = km2;
                n.Latitude = latitude;
                n.Longitude = longitude;
                n.DateEstablished = dateEstablished.ToString("d"); //mmddyyyy
                n.ImageURL = imageURL;
                n.NpsLink = npsLink;
                n.State = state;
                n.Visitors = visitors;

                await _context.AddAsync(n);
                await _context.SaveChangesAsync();

                return n;
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE
        [HttpDelete]
        [Authorize]
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
