using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDTOesController : ControllerBase
    {
        private readonly IsuCorpTestData.Context.IsuCorpTestContext context;
        private readonly IsuCorpTestBusiness.ContactDTO contactBusiness;

        public ContactDTOesController(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            contactBusiness = new IsuCorpTestBusiness.ContactDTO(context);
        }


        // GET: api/ContactDTOes
        [HttpGet]
        public async Task<IEnumerable<IsuCorpTestData.Models.ContactDTO>> GetContactDTO()
        {
            return await contactBusiness.GetAll();
        }

        // GET: api/ContactDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IsuCorpTestData.Models.ContactDTO>> GetContactDTO(long id)
        {
            var reservationDTO = contactBusiness.GetByIdAsync(id);

            if (reservationDTO == null)
            {
                return NotFound();
            }

            return reservationDTO;
        }

        //// PUT: api/ContactDTOes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutContactDTO(long id, ContactDTO contactDTO)
        //{
        //    if (id != contactDTO.ContactId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(contactDTO).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactDTOExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ContactDTOes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ContactDTO>> PostContactDTO(ContactDTO contactDTO)
        //{
        //    _context.ContactDTO.Add(contactDTO);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetContactDTO", new { id = contactDTO.ContactId }, contactDTO);
        //}

        //// DELETE: api/ContactDTOes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteContactDTO(long id)
        //{
        //    var contactDTO = await _context.ContactDTO.FindAsync(id);
        //    if (contactDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ContactDTO.Remove(contactDTO);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ContactDTOExists(long id)
        //{
        //    return _context.ContactDTO.Any(e => e.ContactId == id);
        //}
    }
}
