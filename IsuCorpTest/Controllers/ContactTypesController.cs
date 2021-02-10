using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly IsuCorpTestData.Context.IsuCorpTestContext context;
        private readonly IsuCorpTestBusiness.ContactType contactTypeBusiness;

        public ContactTypesController(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            contactTypeBusiness = new IsuCorpTestBusiness.ContactType(context);
        }

        // GET: api/ContactTypes
        [HttpGet]
        public async Task<IEnumerable<IsuCorpTestData.Models.ContactType>> GetContactType()
        {
            return await contactTypeBusiness.GetAll();   
        }

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IsuCorpTestData.Models.ContactType>> GetContactType(long id)
        {
            var contactType = await contactTypeBusiness.GetByIdAsync(id);

            if (contactType == null)
            {
                return NotFound("Contact type not found");
            }

            return contactType;
        }

        // PUT: api/ContactTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactType(long id, IsuCorpTestData.Models.ContactType contactType)
        {
            if (id != contactType.ContactTypeId)
            {
                return BadRequest("Bad Request");
            }

            if (ModelState.IsValid)
            {
                contactTypeBusiness.Update(contactType);
                await contactTypeBusiness.SaveChangeAsync();
            }

            return NoContent();
        }

        // POST: api/ContactTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IsuCorpTestData.Models.ContactType>> PostContactType(IsuCorpTestData.Models.ContactType contactType)
        {
            if (ModelState.IsValid)
            {
                contactTypeBusiness.Add(contactType);
                await contactTypeBusiness.SaveChangeAsync();
            }

            return CreatedAtAction("GetContactType", new { id = contactType.ContactTypeId }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactType(long id)
        {
            var contactType = await contactTypeBusiness.GetByIdAsync(id);

            if (contactType == null)
            {
                return NotFound("Contact type not found");
            }

            contactTypeBusiness.Remove(contactType);
            await contactTypeBusiness.SaveChangeAsync();

            return NoContent();
        }

        //private bool ContactTypeExists(long id)
        //{
        //    return context.ContactType.Any(e => e.ContactTypeId == id);
        //}
    }
}
