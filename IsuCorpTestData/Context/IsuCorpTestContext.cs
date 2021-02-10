using IsuCorpTestData.Models;
using Microsoft.EntityFrameworkCore;

namespace IsuCorpTestData.Context
{
    public class IsuCorpTestContext : DbContext
    {
        public IsuCorpTestContext(DbContextOptions<IsuCorpTestContext> options) : base(options)
        {

        }

        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ReservationDTO> ReservationDTO { get; set; }
        public DbSet<ContactDTO> ContactDTO { get; set; }
    }
}
