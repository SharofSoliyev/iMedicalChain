using iMedicalChain.Core;
using Microsoft.EntityFrameworkCore;

namespace iMedicalChain.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SickSheet> SickSheets { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }



    }
}
