using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleWebApi.Model
{
    public class Vehicle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int VehicleID { get; set; }

        [Required]
        public string Vehicle_Type { get; set; }

        [Required]
        public int No_of_Seats { get; set; }

        [Required]
        public int Cost_Per_Km { get; set; }

        [Required]
        public int Number_InStock { get; set; }

    }
}
