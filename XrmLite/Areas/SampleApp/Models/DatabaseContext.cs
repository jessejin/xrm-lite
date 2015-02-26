using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using XrmLite.SampleApp.Models;

namespace XrmLite.Models
{
    public partial class DatabaseContext
    {

        public DbSet<Contact> Contacts { get; set; }

    }
}