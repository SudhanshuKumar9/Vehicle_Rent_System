using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Vehicle
    {
       
        public int VehicleID { get; set; }

        
        public string Vehicle_Type { get; set; }

       
        public int No_of_Seats { get; set; }

       
        public int Cost_Per_Km { get; set; }

       
        public int Number_InStock { get; set; }
    }
}
