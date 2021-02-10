using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IsuCorpTestData.Context.IsuCorpTestContext context;
        private readonly IsuCorpTestBusiness.Reservation reservationBusiness;

        public ReservationsController(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            reservationBusiness = new IsuCorpTestBusiness.Reservation(context);
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<IEnumerable<IsuCorpTestData.Models.Reservation>> GetReservation()
        {
            return await reservationBusiness.GetAll();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IsuCorpTestData.Models.Reservation>> GetReservation(long id)
        {
            var reservation = await reservationBusiness.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound("Reservation not found");
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(long id, IsuCorpTestData.Models.Reservation reservation)
        {
            if (id != reservation.RevervationId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                reservationBusiness.Update(reservation);
                await reservationBusiness.SaveChangeAsync();
            }

            return NoContent();
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IsuCorpTestData.Models.Reservation>> PostReservation(IsuCorpTestData.Models.Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservationBusiness.Add(reservation);
                await reservationBusiness.SaveChangeAsync();
            }

            return CreatedAtAction("GetReservation", new { id = reservation.RevervationId }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(long id)
        {
            var reservation = await reservationBusiness.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound("Reservation not found");
            }

            reservationBusiness.Remove(reservation);
            await reservationBusiness.SaveChangeAsync();

            return NoContent();
        }

        //private bool ReservationExists(long id)
        //{
        //    return _context.Reservation.Any(e => e.RevervationId == id);
        //}
    }
}
