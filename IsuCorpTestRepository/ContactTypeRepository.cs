using IsuCorpTestServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestRepository
{
    public class ContactTypeRepository<ContacType> : IContactType<ContacType> where ContacType : class
    {

        IsuCorpTestData.Context.IsuCorpTestContext context;
        DbSet<ContacType> dbContacType;

        public ContactTypeRepository(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            dbContacType = context.Set<ContacType>();
        }

        public void Add(ContacType contactType)
        {
            dbContacType.Add(contactType);
        }

        public void Remove(ContacType contactType)
        {
            dbContacType.Remove(contactType);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Task<ContacType>.Run(() =>
            {
                return context.SaveChangesAsync();
            });
        }

        public void Update(ContacType contactType)
        {
            context.Entry<ContacType>(contactType).State = EntityState.Modified;
        }

        public async Task<IEnumerable<ContacType>> GetAll()
        {
            return await dbContacType.ToListAsync();
        }

        public async Task<ContacType> GetByIdAsync(long id)
        {
            var contactType = await dbContacType.FindAsync(id);
            //var a = dbContacType.ToList().Cast<List<IsuCorpTestData.Models.ContactType>>().ToList();
            
            //IEnumerable<ContacType> lines = dbContacType.ToList();
            //((List<IsuCorpTestData.Models.ContactType>)lines).Where(w => w.ContactTypeName == "Test 1").FirstOrDefault();

            return contactType;
        }

    }
}
