using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestServices
{
    public interface IContact<Contact>
    {
        Task<Contact> GetByIdAsync(long id);
        Task<IEnumerable<Contact>> GetAll();
        IsuCorpTestData.Models.Contact GetByName(string name);
        void Remove(Contact contact);
        void Add(Contact contact);
        void Update(Contact contact);
        Task<int> SaveChangeAsync();

    }
}
