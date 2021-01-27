using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IsuCorpTest.Context;
using IsuCorpTest.Models;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDTOController : ControllerBase
    {
        private readonly IsuCorpTestContext _context;

        public ReservationDTOController(IsuCorpTestContext context)
        {
            _context = context;
        }

        // GET: api/ReservationDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationDTO()
        {
            return await _context.ReservationDTO.FromSqlRaw("GetReservation ").ToListAsync();
        }

        // GET: api/ReservationDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(long id)
        {
            return _context.ReservationDTO.FromSqlRaw($"GetReservation {id}").ToList().FirstOrDefault();
        }

        // PUT: api/ReservationDTO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationDTO(long id, ReservationDTO reservationDTO)
        {
            if (id != reservationDTO.RevervationId)
            {
                return BadRequest();
            }

            _context.Entry(reservationDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationDTOExists(id))
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

        // POST: api/ReservationDTO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> PostReservationDTO(ReservationDTO reservationDTO)
        {
            _context.ReservationDTO.Add(reservationDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationDTO", new { id = reservationDTO.RevervationId }, reservationDTO);
        }

        // DELETE: api/ReservationDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationDTO(long id)
        {
            var reservationDTO = await _context.ReservationDTO.FindAsync(id);
            if (reservationDTO == null)
            {
                return NotFound();
            }

            _context.ReservationDTO.Remove(reservationDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationDTOExists(long id)
        {
            return _context.ReservationDTO.Any(e => e.RevervationId == id);
        }
    }
}
