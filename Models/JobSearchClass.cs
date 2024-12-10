using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOBSEARCHPORTAL.Models
{
    public class JobSearchClass
    {
        public JobSearchClass()
        {
            selectjob = new List<Jobsearch>();
            insertse = new Jobsearch();
        }
       
        public Jobsearch insertse { set; get; }
        
        public List<Jobsearch> selectjob { set; get; }
    }
    public class Jobsearch
    {
        
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }       
        public string JobSkills { get; set; }
        public string JobExperience { get; set; }
        public string JobType { get; set; }
        public string JobWorkMode { get; set; }
        public string JobLocation { get; set; }
        public string JobSalaryRange { get; set; }
        public DateTime JobEndDate { get; set; }
        public string JobStatus { get; set; }
        public string JobMsg { get; set; }
    }

}