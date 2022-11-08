using Diploma.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DbContexts
{
    public class DiplomaDbContext : DbContext
    {
        public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Visit>().Property(x => x.VisitId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Examination>().Property(x => x.ExaminationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Medicine>().Property(x => x.MedicineId).ValueGeneratedOnAdd();
            modelBuilder.Entity<PriceList>().Property(x => x.PriceId).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PriceList> ServicesPrices { get; set; }
    }
}
