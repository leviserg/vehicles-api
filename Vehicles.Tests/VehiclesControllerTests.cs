using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vehicles_api.Controllers;
using vehicles_api.Models;
using Xunit;

namespace Vehicles.Tests
{
    public class VehiclesControllerTests
    {
        [Fact]
        public void Get()
        {

            // Arrange
            var mock = new Mock<IVehiclesRepository>();
            mock.Setup(repo => repo.Get(2)).Returns(GetVehicle(2));

            // Act
            var result = mock.Object.Get(2);

            // Assert
            //Assert.NotNull(result);
            Assert.IsType<Vehicle>(result);
        }

        [Fact]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(databaseName: "VehiclesDb")
                //.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=VehiclesDb;Uid=root;Pwd=1111;")
                .Options;

            /*
            using (var context = new VehicleDbContext(options))
            {
                context.Vehicles.Add(new Vehicle
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
                context.Vehicles.Add(new Vehicle
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
                context.Vehicles.Add(new Vehicle
                {
                    Brand = "KIA",
                    Model = "Ceed",
                    Year = 2018,
                    Mileage = 33450,
                    Price = 9999,
                    Status = "good",
                    Location = "EU",
                    ImageUrl = "https://avtofishki.com.ua/image/catalog/cat/kia/foto-avto-kia-ceed-s-2018.jpg"
                });
                context.SaveChanges();
            }
            */

            using (var context = new VehicleDbContext(options))
            {
                VehicleRepository vehicleRepository = new VehicleRepository(context);
                IEnumerable<Vehicle> vehicles = vehicleRepository.GetAll();
                Assert.Equal(3, vehicles.Count());
            }
        }

        private Vehicle GetVehicle(int id)
        {
            return new Vehicle
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2020,
                Mileage = 48971,
                Price = 12500,
                Status = "perfect",
                Location = "EU",
                ImageUrl = "https://i.infocar.ua/i/12/4353/1400x700.jpg"
            };
        }

    }
}
