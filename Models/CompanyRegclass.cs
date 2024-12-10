using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHPORTAL.Models
{
    public class CompanyRegclass
    {


        [Required(ErrorMessage = "Enter the company name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Enter the company address")]

        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Enter the company email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string CompanyEmail { get; set; }

        [Required(ErrorMessage = "Enter the company website")]

        public string CompanyWebsite { get; set; }

        [Required(ErrorMessage = "Enter the company phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter a valid 10-digit phone number")]
        public string Company_Phone { get; set; }

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