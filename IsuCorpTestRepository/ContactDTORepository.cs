using IsuCorpTestServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IsuCorpTestRepository
{
    public class ContactDTORepository<ContactDTO> : IContactDTO<ContactDTO> where ContactDTO : class
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        DbSet<ContactDTO> dbContactDTO;

        public ContactDTORepository(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            dbContactDTO = context.Set<ContactDTO>();
        }

        public void Add(ContactDTO contactDTO)
        {
            dbContactDTO.Add(contactDTO);
        }

        public async Task<IEnumerable<ContactDTO>> GetAll()
        {
            return await dbContactDTO.FromSqlRaw($"GetContact").ToListAsync();
        }

        public ContactDTO GetByIdAsync(long id)
        {
            var contactDTO = ((IEnumerable<ContactDTO>)dbContactDTO.FromSqlRaw($"GetContact {id}")).ToList().FirstOrDefault();

            return contactDTO;
        }

        public void Remove(ContactDTO contactDTO)
        {
            dbContactDTO.Remove(contactDTO);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Task<ContactDTO>.Run(() =>
            {
                return context.SaveChangesAsync();
            });
        }

        public void Update(ContactDTO contactDTO)
        {
            context.Entry<ContactDTO>(contactDTO).State = EntityState.Modified;
        }
    }
}
