using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hotel.Models
{
    public class FeedBack
    {
        public int ID { get; set; }
        [DisplayName("Hotel Name")]
        public string Subject { get; set; }
        [DisplayName("Details about the Feedback of Hotel")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        // Hotel ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string HotelID { get; set; }
    }
}