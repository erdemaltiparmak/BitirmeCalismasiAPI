using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Models
{
    public class BitirmeContext:DbContext
    {
        public BitirmeContext(DbContextOptions<BitirmeContext> options) : base(options)
        {

        }

        public DbSet<Hasta> Hastas { get; set; }
        public DbSet<Bileklik> Bilekliks { get; set; }
        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bileklik>().HasKey(x => x.BileklikID);
            modelBuilder.Entity<Hasta>().HasKey(x => x.HastaID);
            modelBuilder.Entity<Personel>().HasKey(x => x.PersonelID);
        }


    }
}
