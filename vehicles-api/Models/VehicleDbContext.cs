using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicles_api.Models
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
