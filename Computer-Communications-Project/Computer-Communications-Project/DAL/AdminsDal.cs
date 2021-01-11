using Computer_Communications_Project.Models;
using System.Data.Entity;

namespace Computer_Communications_Project.DAL
{
    public class AdminsDal : DbContext
    {
        public DbSet<Admin> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("tblAdmins");
        }
    }
}