using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bar.Models
{
    public class BarContext : DbContext
    {
        public BarContext (DbContextOptions<BarContext> options)
            : base(options)
        {
        }

        public DbSet<Bar.Models.BarMenu> BarMenu { get; set; }
        public DbSet<Bar.Models.Order> Order { get; set; }
    }
}
