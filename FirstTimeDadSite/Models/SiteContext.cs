using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTimeDadSite.Models
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {

        }

        //Add all models (classes) as DbSet that need to be tracked by the database
        public DbSet<Member> Members { get; set; }

        public DbSet<Tips> Tips { get; set; }
    }
}
