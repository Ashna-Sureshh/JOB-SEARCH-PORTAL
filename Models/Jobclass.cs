using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOBSEARCHPORTAL.Models
{
    public class Jobclass
    {
        public int cid { get; set; }
        [Required(ErrorMessage = "Job Title is required.")]
   
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Job Description is required.")]

        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Job Skills are required.")]

        public string JobSkills { get; set; }

        [Required(ErrorMessage = "Job Experience is required.")]

        public string JobExperience { get; set; }

        [Required(ErrorMessage = "Job Type is required.")]

        public string JobType { get; set; }

        [Required(ErrorMessage = "Job Work Mode is required.")]

        public string JobWorkMode { get; set; }

        [Required(ErrorMessage = "Job Location is required.")]

        public string JobLocation { get; set; }

        [Required(ErrorMessage = "Job Salary Range is required.")]

        public string JobSalaryRange { get; set; }

        [Required(ErrorMessage = "Job End Date is required.")]

        public DateTime JobEndDate { get; set; }

        [Required(ErrorMessage = "Job Status is required.")]

        public string JobStatus { get; set; }

        public string Msg { get; set; }
    }
}