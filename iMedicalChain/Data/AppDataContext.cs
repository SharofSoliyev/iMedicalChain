using iMedicalChain.Core;
using Microsoft.EntityFrameworkCore;

namespace iMedicalChain.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SickSheet> SickSheets { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<SickHistory> SickHistories { get; set; }

        public DbSet<Doctors> Doctors { get; set; }

        public DbSet<ChainUsers> ChainUsers { get; set; }
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }



    }
}
