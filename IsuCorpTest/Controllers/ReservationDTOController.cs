using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDTOController : ControllerBase
    {
        private readonly IsuCorpTestData.Context.IsuCorpTestContext context;
        private readonly IsuCorpTestBusiness.ReservationDTO reservationBusiness;

        public ReservationDTOController(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            reservationBusiness = new IsuCorpTestBusiness.ReservationDTO(context);
        }

        // GET: api/ReservationDTO
        [HttpGet]
        public async Task<IEnumerable<IsuCorpTestData.Models.ReservationDTO>> GetReservationDTO()
        {
            return await reservationBusiness.GetAll();
        }

        // GET: api/ReservationDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IsuCorpTestData.Models.ReservationDTO>> GetReservation(long id)
        {
            var reservationDTO = reservationBusiness.GetByIdAsync(id);

            if (reservationDTO == null)
            {
                return NotFound("Reservation not found");
            }

            return reservationDTO;
        }

        //// PUT: api/ReservationDTO/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReservationDTO(long id, IsuCorpTestData.Models.ReservationDTO reservationDTO)
        //{
            
        //}

        //// POST: api/ReservationDTO
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ReservationDTO>> PostReservationDTO(ReservationDTO reservationDTO)
        //{
            

        //    return CreatedAtAction("GetReservationDTO", new { id = reservationDTO.RevervationId }, reservationDTO);
        //}

        //// DELETE: api/ReservationDTO/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReservationDTO(long id)
        //{
            
        //}

        //private bool ReservationDTOExists(long id)
        //{
        //    return _context.ReservationDTO.Any(e => e.RevervationId == id);
        //}
    }
}
