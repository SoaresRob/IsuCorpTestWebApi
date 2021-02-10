using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestServices
{
    public interface IContactType<ContactType>
    {
        Task<ContactType> GetByIdAsync(long id);
        Task<IEnumerable<ContactType>> GetAll();
        void Remove(ContactType contactType);
        void Add(ContactType contactType);
        void Update(ContactType contactType);
        Task<int> SaveChangeAsync();

    }
}
