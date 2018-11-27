using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Hotel
    {
        [Required(ErrorMessage = "Please enter Hotel's Name")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "Please enter a valid email address")]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Please enter Hotel ID")]
        public string HotelID { get; set; }

        [Required(ErrorMessage = "Please enter Hotel Rating")]
        public double Ratings { get; set; }

        [Required(ErrorMessage = "Please enter Hotel Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter Hotel Facilities")]
        public string[] Facilities { get; set; }

        [Required(ErrorMessage = "Please enter Hotel's Upper Price Range")]
        public double PriceRangeUpper { get; set; }

        [Required(ErrorMessage = "Please enter Hotel's Lower Price Range")]
        public double PriceRangeLower { get; set; }

        [Required]
        public int RoomAvailable { get; set; }
    }
}