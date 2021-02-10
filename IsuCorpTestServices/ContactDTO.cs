using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestServices
{
    public interface IContactDTO<ContactDTO>
    {
        ContactDTO GetByIdAsync(long id);
        Task<IEnumerable<ContactDTO>> GetAll();
        void Remove(ContactDTO contactDTO);
        void Add(ContactDTO contactDTO);
        void Update(ContactDTO contactDTO);
        Task<int> SaveChangeAsync();
    }
}
