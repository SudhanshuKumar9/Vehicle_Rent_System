using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApi.Model;
using AuthenticateApi.Models;

namespace BookingMS.Model
{
    public class Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int BookingID { get; set; }

        [ForeignKey("User")]
        public string Username{ get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_of_Booking { get; set; }

        [Required]
        public int Total_Km { get; set; }

        public int Total_Fare { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual User User { get; set; }



    }
}
