using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicles_api.Models;

namespace vehicles_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleDbContext _db;

        public VehiclesController(VehicleDbContext context)
        {
            _db = context;
        }

        // GET api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            var items = _db.Vehicles.OrderByDescending(u => u.Price).Take(7);
            return await items.ToListAsync();
        }

        // GET api/vehicles/more/1
        [HttpGet("more/{stepid}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetMore(int stepid)
        {
            stepid = (stepid < 0) ? 0 : stepid;
            var items = _db.Vehicles.OrderByDescending(u => u.Price).Skip(stepid*7).Take(7);
            return await items.ToListAsync();
        }

        // GET api/vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Get(int id)
        {
            Vehicle vehicle = await _db.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
            if (vehicle == null)
                return NotFound();
            return new ObjectResult(vehicle);
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Add(vehicle);
                await _db.SaveChangesAsync();
                return Ok(vehicle);
            }
            return BadRequest();
        }

        // PUT api/vehicles
        [HttpPut]
        public async Task<ActionResult<Vehicle>> Put(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            if (!_db.Vehicles.Any(x => x.VehicleId == vehicle.VehicleId))
            {
                return NotFound();
            }

            _db.Update(vehicle);
            await _db.SaveChangesAsync();
            return Ok(vehicle);
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> Delete(int id)
        {
            Vehicle vehicle = _db.Vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _db.Vehicles.Remove(vehicle);
            await _db.SaveChangesAsync();
            return Ok(vehicle);
        }
    }
}
