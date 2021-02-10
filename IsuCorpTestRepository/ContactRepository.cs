using IsuCorpTestServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsuCorpTestRepository
{
    public class ContactRepository<Contact> : IContact<Contact> where Contact : class
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        DbSet<Contact> dbContact;

        public ContactRepository(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            dbContact = context.Set<Contact>();
        }

        public void Add(Contact contact)
        {
            dbContact.Add(contact);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await dbContact.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            var contact = await dbContact.FindAsync(id);

            return contact;
        }
        public IsuCorpTestData.Models.Contact GetByName(string name)
        {
            //var contact = dbContact.ToList().FirstOrDefault();//.Where(w => w.ContactName == name).FirstOrDefault();
            //IEnumerable<ContacType> lines = dbContacType.ToList();

            var contact =  (((List<IsuCorpTestData.Models.Contact>)((IEnumerable<Contact>)dbContact.ToList())).Where(w => w.ContactName == name).FirstOrDefault());

            return contact;
        }


        public void Remove(Contact contact)
        {
            dbContact.Remove(contact);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Task<Contact>.Run(() =>
            {
                return context.SaveChangesAsync();
            });
        }

        public void Update(Contact contact)
        {
            context.Entry<Contact>(contact).State = EntityState.Modified;
        }
    }
}
