using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CIT195Project.Models;

namespace CIT195Project.Data
{
    public class HawksContext : DbContext
    {
        public HawksContext (DbContextOptions<HawksContext> options)
            : base(options)
        {
        }

        public DbSet<CIT195Project.Models.Hawk> Hawk { get; set; } = default!;
    }
}
