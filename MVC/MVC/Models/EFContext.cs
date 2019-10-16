using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EFContext : DbContext
    {        
            public EFContext()
                : base("name=cnStr")
            {

            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //Example of using FluentAPI
                //modelBuilder.Entity<Customer>()
                //     .HasMany<Customer>(c => c.Customer)
                //     .WithRequired(cus => cus.Country)
                //     .HasForeignKey(cus => cus.CountryID)
                //     .WillCascadeOnDelete(false);

            }

            public virtual DbSet<Customer> Customers { get; set; }
        }

    }
