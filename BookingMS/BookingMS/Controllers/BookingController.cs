using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticateApi.Repos;
using BookingMS.Model;
using BookingMS.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookRepository _repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingController));
        public BookingController(IBookRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returning List of Booking by getting username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>IEnumerable<Booking></returns>

        [HttpGet("{username}")]
        public IActionResult GetAllBooking(string username)
        {
            try
            {
                _log4net.Info(nameof(GetAllBooking) + " method invoked from " + nameof(BookingController));
                return Ok(_repository.GetAllBookings(username).ToList());
            }
            catch(Exception e)
            {
                _log4net.Error("Error occured from " + nameof(GetAllBooking) + " Error message: " + e.Message);
                return NotFound();
            }
            
        }

        /// <summary>
        /// Saving details of Booking to database.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>StatusCode</returns>

        [HttpPost]
        public ActionResult SaveBooking(Booking booking)
        {
            try
            {
                _log4net.Info(nameof(SaveBooking) + " method invoked from " + nameof(BookingController));
                _repository.SaveBooking(booking);
                return Ok(StatusCodes.Status201Created);
            }

            catch(Exception e)
            {
                _log4net.Error("Error occured from " + nameof(SaveBooking) + " Error message: " + e.Message);
                return NotFound();
            }
           
        }

    }
}
