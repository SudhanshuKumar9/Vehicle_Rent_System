using BookingMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingMS.Repo
{
    public interface IBookRepository
    {
        IEnumerable<Booking> GetAllBookings(string username);

        void SaveBooking(Booking booking);
    }
}
