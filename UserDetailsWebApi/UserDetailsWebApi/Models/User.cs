using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateApi.Models
{
    public class User
    {

        [Required]
        public string Name { get; set; }

        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public long Contact_Number { get; set; }
    }
}
