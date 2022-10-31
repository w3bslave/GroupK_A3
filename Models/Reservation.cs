using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Xml.Linq;

namespace GroupK_A3.Models
{
    public class Reservation
    {
        //Personal Details
        public int Id { get; set; } 

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Please enter a valid Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Home Address")]
        [Required]
        public string HomeAddress { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        private RoomType roomtype;

        //Booking Details
        public RoomType GetRoomtype()
        {
            return roomtype;
        }

        //Booking Details
        public void SetRoomtype(RoomType value)
        {
            roomtype = value;
        }

        public int RoomID { get; set; }

        [Display(Name = "Total Person Staying")]
        [Required]
        public int TotalPerson { get; set; }

        [Display(Name = "Check-in Date")]
        [Required]
        public DateTime CheckinDateTime { get; set; }

        [Display(Name = "Check-out Date")]
        [Required]
        public DateTime CheckoutDateTime { get; set; }

        [NotMapped]
        public string CheckinDate => CheckinDateTime.ToString("MM/dd/yyyy");

        [NotMapped]
        public string CheckinTime => CheckoutDateTime.ToString("hh:mm tt");

        [NotMapped]
        public string CheckoutDate => CheckoutDateTime.ToString("MM/dd/yyyy");

        [NotMapped]
        public string CheckouTime => CheckoutDateTime.ToString("hh:mm tt");

        public string SpecialRequest { get; set; }


        public Reservation()
        {

        }

    }
}