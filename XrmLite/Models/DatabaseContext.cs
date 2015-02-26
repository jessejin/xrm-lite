using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XrmLite.Models
{
    public partial class DatabaseContext: IdentityDbContext<XrmUser>
    {

        public DatabaseContext()
            : base("XrmLiteConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<XrmUser>()
                .ToTable("Users");
        }

        public DbSet<PickListValue> PickListValues { get; set; }

    }
}