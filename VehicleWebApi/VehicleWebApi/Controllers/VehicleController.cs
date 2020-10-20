using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Model;
using VehicleWebApi.Repo;

namespace VehicleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VehicleController));
        private readonly IRepository _repository;

        public VehicleController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returning List of Vehicles to the MVC client.
        /// </summary>
        /// <param></param>
        /// <returns>IEnumerable<Vehicles></returns>

        [HttpGet]
        public List<Vehicle> GetAllVehicles()
        {
            try
            {
                _log4net.Info(nameof(GetAllVehicles)+" method invoked from " + nameof(VehicleController));
                var result = _repository.GetVehicles();
                return result.ToList();
            }
            catch(Exception e)
            {
                _log4net.Error("Error occured from " + nameof(GetAllVehicles) + " Error message: " + e.Message);
                return null;
            }

            
        }

        /// <summary>
        /// Returning vehicle details by getting vehicle id from MVC client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vehicle</returns>

        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            try
            {
                _log4net.Info(nameof(GetVehicle) + " method invoked from " + nameof(VehicleController));
                var vehicle = _repository.GetVehicle(id);
                if (vehicle != null)
                    return Ok(vehicle);
                return NotFound();
            }
            catch(Exception e)
            {
                _log4net.Error("Error occured from " + nameof(GetVehicle) + " Error message: " + e.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Updating details of vehicle by getting id from the MVC client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode</returns>

        [HttpPatch("{id}")]
        public IActionResult UpdateVehicle(int id)
        {
            var vehicle =_repository.UpdateVehicle(id);
            if (vehicle != null)
            {
                return Ok(HttpStatusCode.Created);
            }
            return NotFound();
            
        }
       
    }
}
