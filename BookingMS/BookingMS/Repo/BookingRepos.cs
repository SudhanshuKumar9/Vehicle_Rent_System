
using BookingMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticateApi.Models;
using VehicleWebApi.Model;

namespace BookingMS.Repo
{
    public class BookingRepos : IBookRepository
    {
        private readonly BookingContext _context;

        public BookingRepos(BookingContext context)
        {
            _context = context;
        }
        public IEnumerable<Booking> GetAllBookings(string username)
        {
            return _context.Bookings.ToList().Where(b=>b.Username==username);
        }

        public void SaveBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
    }
}
