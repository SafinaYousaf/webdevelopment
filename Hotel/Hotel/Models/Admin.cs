using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "Please enter Hotel's List")]
        public List<Hotel> HotelList { get; set; }
    }
}


