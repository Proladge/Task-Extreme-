using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class ExtremeDbContext : DbContext
    {
        public ExtremeDbContext()
            :base("DbConnection")
        { }
        public DbSet<Post> Posts { get; set; }
     public   DbSet<Service> Services { get; set; }
    }
}