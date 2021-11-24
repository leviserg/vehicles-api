using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicles_api.Models
{
    public class VehicleSeeder
    {
        private readonly VehicleDbContext _context;
        public VehicleSeeder(VehicleDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {

            AddNewVehicle(new Vehicle {
                Brand = "KIA",
                Model = "Ceed",
                Year = 2018,
                Mileage = 33450,
                Price = 9999,
                Status = "good",
                Location = "EU",
                ImageUrl = "https://avtofishki.com.ua/image/catalog/cat/kia/foto-avto-kia-ceed-s-2018.jpg"
            });

            AddNewVehicle(new Vehicle
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2020,
                Mileage = 48971,
                Price = 12500,
                Status = "perfect",
                Location = "EU",
                ImageUrl = "https://i.infocar.ua/i/12/4353/1400x700.jpg"
            });

            AddNewVehicle(new Vehicle
            {
                Brand = "Hyundai",
                Model = "IX35",
                Year = 2018,
                Mileage = 25600,
                Price = 13699,
                Status = "good",
                Location = "USA",
                ImageUrl = "https://images.ua.prom.st/1770729182_nakladka-na-kryshku.jpg"
            });

            _context.SaveChanges();
        }

        private void AddNewVehicle(Vehicle vehicle)
        {
            var existingType = _context.Vehicles.FirstOrDefault(p => p.VehicleId == vehicle.VehicleId);
            if (existingType == null)
            {
                _context.Vehicles.Add(vehicle);
            }
        }
    }
}
