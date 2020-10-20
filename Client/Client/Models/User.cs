using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User
    {
        
        public string Name { get; set; }

       
        public string Username { get; set; }

       
        public string Password { get; set; }


       
        public long Contact_Number { get; set; }
    }
}
