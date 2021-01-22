using Computer_Communications_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.DAL
{
    public class HallsDal : DbContext
    {
        public DbSet<Hall> Halls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hall>().ToTable("tblHalls");
        }
    }
}