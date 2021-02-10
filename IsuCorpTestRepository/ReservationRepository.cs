using IsuCorpTestServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsuCorpTestRepository
{
    public class ReservationRepository<Reservation> : IReservationService<Reservation> where Reservation : class
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        DbSet<Reservation> dbReservation;

        public ReservationRepository(IsuCorpTestData.Context.IsuCorpTestContext context)
        {
            this.context = context;
            dbReservation = context.Set<Reservation>();
        }

        public void Add(Reservation contactType)
        {
            dbReservation.Add(contactType);
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await dbReservation.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(long id)
        {
            var contactType = await dbReservation.FindAsync(id);

            return contactType;
        }

        public void Remove(Reservation contactType)
        {
            dbReservation.Remove(contactType);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Task<Reservation>.Run(() =>
            {
                return context.SaveChangesAsync();
            });
        }

        public void Update(Reservation contactType)
        {
            context.Entry<Reservation>(contactType).State = EntityState.Modified;
        }
    }
}
