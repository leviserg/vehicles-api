using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vehicles_api.Models;

namespace Vehicles.Tests
{
    public interface IVehiclesRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle Get(int id);
        void Create(Vehicle vehicle);
    }
}
