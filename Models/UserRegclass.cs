using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHPORTAL.Models
{
    public class UserRegclass
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your age")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter your email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your skills")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Enter your experience")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Enter your location")]
        public string Location { get; set; }

        public string Photo { get; set; }

        [Required(ErrorMessage = "Enter your qualification")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Enter your job preferences")]
        public string Preferences { get; set; }

        [Required(ErrorMessage = "Enter the username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string CPassword { get; set; }

        public string Msg { get; set; }
    }
}
