using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace XrmLite.Models
{
    public class DatabaseContext: DbContext
    {

        public DatabaseContext()
            : base("XrmLiteConnectionString")
        {

        }
        public DbSet<Contact> Contacts { get; set; } 

    }
}