using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsuCorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IsuCorpTestData.Context.IsuCorpTestContext context;
        private readonly IsuCorpTestBusiness.Contact contactBusiness;

        public ContactsController(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            contactBusiness = new IsuCorpTestBusiness.Contact(context);
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<IsuCorpTestData.Models.Contact>> GetContact()
        {
            return await contactBusiness.GetAll();
        }

        // GET: api/Contacts/5
        [HttpGet("{id},{name}")]
        public async Task<ActionResult<IsuCorpTestData.Models.Contact>> GetContact(long id, string name = null)
        {
            var contact = new IsuCorpTestData.Models.Contact();

            if (id != 0)
            {
                contact = await contactBusiness.GetByIdAsync(id);
            }
            else
            {
                contact = contactBusiness.GetByName(name);
            }

            if (contact == null)
            {
                return NotFound("Contact not found");

                //return contact = new IsuCorpTestData.Models.Contact { ContactId = 0 };
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, IsuCorpTestData.Models.Contact contact)
        {
            if (id != contact.ContactId)
            {
                return BadRequest("Bad Request");
            }

            if (ModelState.IsValid)
            {
                contactBusiness.Update(contact);
                await contactBusiness.SaveChangeAsync();
            }

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IsuCorpTestData.Models.Contact>> PostContact(IsuCorpTestData.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactBusiness.Add(contact);
                await contactBusiness.SaveChangeAsync();
            }

            return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await contactBusiness.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            contactBusiness.Remove(contact);
            await contactBusiness.SaveChangeAsync();

            return NoContent();
        }

        //private bool ContactExists(long id)
        //{
        //    return _context.Contact.Any(e => e.ContactId == id);
        //}
    }
}
