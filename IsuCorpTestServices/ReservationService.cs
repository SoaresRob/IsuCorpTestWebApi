using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestServices
{
    public interface IReservationService<Reservation>
    {
        Task<Reservation> GetByIdAsync(long id);
        Task<IEnumerable<Reservation>> GetAll();
        void Remove(Reservation contactType);
        void Add(Reservation contactType);
        void Update(Reservation contactType);
        Task<int> SaveChangeAsync();

    }
}
