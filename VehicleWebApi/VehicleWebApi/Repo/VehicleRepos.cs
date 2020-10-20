using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApi.Model;

namespace VehicleWebApi.Repo
{
    public class VehicleRepos : IRepository
    {
        private readonly VehicleContext _context;

        public VehicleRepos(VehicleContext context)
        {
            _context = context;
        }
        public Vehicle GetVehicle(int id)
        {
            return _context.Vehicles.FirstOrDefault(v => v.VehicleID == id);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Vehicles.Where(v=>v.Number_InStock>0).ToList();
        }

        public async Task<Vehicle> SaveVehicle(Vehicle vehicle)
        {
           
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(int id)
        {
            var vehicle = _context.Vehicles.Where(v => v.VehicleID == id).FirstOrDefault();
            if (vehicle != null)
            {
                vehicle.Number_InStock -= 1;
                await _context.SaveChangesAsync();
            }

            return vehicle;
           
            
        }

     
    }
}
