using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ViewModel
{
    public class BookingViewModel
    {
       

        
        public string Username { get; set; }

        
        public int VehicleID { get; set; }

        
        public DateTime Date_of_Booking { get; set; }

       
        public int Total_Km { get; set; }

        public int Total_Fare { get; set; }

        public  Vehicle Vehicle { get; set; }
        public  User User { get; set; }
    }
}
