using FormulaAirline.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAirline.Database
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext() { }

        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=AirlineDb;User Id=azra;Password=Password123!;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;");
            }
        }
    }
}
