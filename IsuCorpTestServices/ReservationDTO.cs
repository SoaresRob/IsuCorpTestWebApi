using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestServices
{
    public interface IReservationDTO<ReservationDTO>
    {
        ReservationDTO GetByIdAsync(long id);
        Task<IEnumerable<ReservationDTO>> GetAll();
        void Remove(ReservationDTO reservationDTO);
        void Add(ReservationDTO reservationDTO);
        void Update(ReservationDTO reservationDTO);
        Task<int> SaveChangeAsync();
    }
}
