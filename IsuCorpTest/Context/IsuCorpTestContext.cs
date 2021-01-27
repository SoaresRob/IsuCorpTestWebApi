using IsuCorpTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsuCorpTest.Context
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
