using System;
using System.Collections.Generic;
using System.Data.Entity;
using Computer_Communications_Project.Models;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.DAL
{
    public class UsersDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("tblUsers");
        }
        public DbSet<User> Users { get; set; }
        
    }
}