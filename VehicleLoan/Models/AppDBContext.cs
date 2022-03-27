using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VehicleLoan.Models
{
    public class AppDBContext: DbContext
    {
            public AppDBContext() : base("VehicleDBConStr")
            {
                //Empty
            }

            public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Admin> Admins{ get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //        .HasOptional<Loan>(s => s.Loan)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Loan>()
        //        .HasOptional(a => a.Customers)
        //        .WithOptionalDependent()
        //        .WillCascadeOnDelete(true);
        //}
    }
}
