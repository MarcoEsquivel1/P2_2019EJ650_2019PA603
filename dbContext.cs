using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2_2019EJ650_2019PA603.Models;

namespace P2_2019EJ650_2019PA603
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Generos> generos { get; set; }
        public DbSet<Casos> casos { get; set; }


    }
}
