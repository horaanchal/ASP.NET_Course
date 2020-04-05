using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Application.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }


        public static MyDBContext Create()
        {
            return new MyDBContext();
        }

    }
}