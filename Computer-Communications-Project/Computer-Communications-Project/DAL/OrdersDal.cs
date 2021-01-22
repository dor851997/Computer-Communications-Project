using Computer_Communications_Project.Models;
using System.Data.Entity;

namespace Computer_Communications_Project.DAL
{
    public class OrdersDal : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().ToTable("tblOrders");
        }
    }
}