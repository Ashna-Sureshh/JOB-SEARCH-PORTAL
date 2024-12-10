using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class JobSearchConController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();

        // GET: JobSearchCon
        public ActionResult JobSearch_Pageload()
        {
            return View(GetData()); // Show all jobs when the page first loads
        }

        // Fetch all job data
        private JobSearchClass GetData()
        {
            var joblist = new JobSearchClass();
            List<string> lst = new List<string>();

            var jobs = dbobj.JobTabs.ToList();

            foreach (var e in jobs)
            {
                var jobcls = new Jobsearch();

                jobcls.JobId = e.Job_ID;
                jobcls.CompanyId = e.Company_ID;
                jobcls.JobTitle = e.Job_Title;
                jobcls.JobDescription = e.Job_Description;
                jobcls.JobSkills = e.Job_Skills;
                jobcls.JobExperience = e.Job_Experience;
                jobcls.JobType = e.Job_Type;
                jobcls.JobWorkMode = e.Job_WorkMode;
                jobcls.JobLocation = e.Job_Location;
                jobcls.JobSalaryRange = e.Job_SalaryRange;
                jobcls.JobEndDate = e.Job_EndDate;
                jobcls.JobStatus = e.Job_Status;

                joblist.selectjob.Add(jobcls);

                var s = jobcls.JobSkills;
                lst.Add(s);
            }

            TempData["ski"] = string.Join(" ", lst);
            return joblist;
        }




        // Handle the search functionality
        public ActionResult searchjob_click(JobSearchClass clsobj)
        {
            string qry = " ";

            // Add filters dynamically based on user input
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.JobSkills))
                qry += " AND Job_Skills LIKE '%" + clsobj.insertse.JobSkills + "%'";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.JobExperience))
                qry += " AND Job_Experience LIKE '%" + clsobj.insertse.JobExperience + "%'";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.JobLocation))
                qry += " AND Job_Location LIKE '%" + clsobj.insertse.JobLocation + "%'";

            // Call the stored procedure to get the filtered data
            return View("JobSearch_Pageload", GetData1(clsobj,qry));
        }

        // Fetch filtered job data based on the query using stored procedure
        private JobSearchClass GetData1(JobSearchClass clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["newconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                var joblist = new JobSearchClass();

                while (dr.Read())
                {
                    var jobcls = new Jobsearch();
                    jobcls.JobId = Convert.ToInt32(dr["Job_ID"]);
                    jobcls.CompanyId = Convert.ToInt32(dr["Company_ID"]);
                    jobcls.JobTitle = dr["Job_Title"].ToString();
                    jobcls.JobDescription = dr["Job_Description"].ToString();
                    jobcls.JobSkills = dr["Job_Skills"].ToString();
                    jobcls.JobExperience = dr["Job_Experience"].ToString();
                    jobcls.JobType = dr["Job_Type"].ToString();
                    jobcls.JobWorkMode = dr["Job_WorkMode"].ToString();
                    jobcls.JobLocation = dr["Job_Location"].ToString();
                    jobcls.JobSalaryRange = dr["Job_SalaryRange"].ToString();
                    jobcls.JobEndDate = Convert.ToDateTime(dr["Job_EndDate"]);
                    jobcls.JobStatus = dr["Job_Status"].ToString();


                    joblist.selectjob.Add(jobcls);  // Add the job to the list
                }
                con.Close();
                return joblist;  // Return the populated job list
            }
        }




    }
}

