using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XrmLite.Models
{
    public class IndexViewModel
    {
        public System.Data.Entity.DbSet Items { get; set; }
        public string ModelDisplayName { get; set; }

    }
}