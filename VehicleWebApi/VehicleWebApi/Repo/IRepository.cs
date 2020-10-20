using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApi.Model;

namespace VehicleWebApi.Repo
{
    public interface IRepository
    {
        IEnumerable<Vehicle> GetVehicles();

        Vehicle GetVehicle(int id);

        Task<Vehicle> SaveVehicle(Vehicle vehicle);

        Task<Vehicle> UpdateVehicle(int id);


       
    }
}
