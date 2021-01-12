using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Computer_Communications_Project.Models;
using System.Data.Entity;

namespace Computer_Communications_Project.DAL
{
    public class MoviesDal: DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("tblMovies");
        }
    }
}