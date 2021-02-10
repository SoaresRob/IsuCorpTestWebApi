using IsuCorpTestServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IsuCorpTestRepository
{
    public class ReservationDTORepository<ReservationDTO> : IReservationDTO<ReservationDTO> where ReservationDTO : class
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        DbSet<ReservationDTO> dbReservationDTO;

        public ReservationDTORepository(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            dbReservationDTO = context.Set<ReservationDTO>();
        }

        public void Add(ReservationDTO reservationDTO)
        {
            dbReservationDTO.Add(reservationDTO);
        }

        public async Task<IEnumerable<ReservationDTO>> GetAll()
        {
            return await dbReservationDTO.FromSqlRaw("GetReservation ").ToListAsync();
        }

        public ReservationDTO GetByIdAsync(long id)
        {
            var contactType = ((IEnumerable<ReservationDTO>)dbReservationDTO.FromSqlRaw($"GetReservation {id}")).ToList().FirstOrDefault();

            return contactType;
        }

        public void Remove(ReservationDTO reservationDTO)
        {
            dbReservationDTO.Remove(reservationDTO);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Task<ReservationDTO>.Run(() =>
            {
                return context.SaveChangesAsync();
            });
        }

        public void Update(ReservationDTO reservationDTO)
        {
            context.Entry<ReservationDTO>(reservationDTO).State = EntityState.Modified;
        }
    }
}
