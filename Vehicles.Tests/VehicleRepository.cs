using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vehicles_api.Models;

namespace Vehicles.Tests
{
    public class VehicleRepository
    {
        private readonly VehicleDbContext _dbContext;
        public VehicleRepository(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public VehicleDbContext getDbContext()
        {
            return _dbContext;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _dbContext.Vehicles;
        }

        public Vehicle Get(int id)
        {
            return _dbContext.Vehicles.FirstOrDefault(x => x.VehicleId == id);
        }

        public void Create(Vehicle vehicle) {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }
    }
}
