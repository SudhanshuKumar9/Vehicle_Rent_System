using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Booking
    {
        public string Username { get; set; }

       
        public int VehicleID { get; set; }

       
        [DataType(DataType.Date)]
        [DisplayName("Date Of Booking")]
        public DateTime Date_of_Booking { get; set; }

        [Required]
        [DisplayName("Total Days")]
        public int Total_Km { get; set; }

        public int Total_Fare { get; set; }

       
    }
}
