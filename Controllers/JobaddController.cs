using System;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class JobAddController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();

        // GET: Admin Home
        public ActionResult AdminHome()
        {
            return View();
        }

        // POST: Insert Job
        public ActionResult InsertJob_Click(Jobclass clsobj)
        {

            if (ModelState.IsValid)
            {
                int CompId = Convert.ToInt32(Session["usid"]);
                clsobj.cid = CompId;

                dbobj.sp_InsertJob(clsobj.cid, clsobj.JobTitle, clsobj.JobDescription, clsobj.JobSkills, clsobj.JobExperience, clsobj.JobType, clsobj.JobWorkMode, clsobj.JobLocation, clsobj.JobSalaryRange, clsobj.JobEndDate, clsobj.JobStatus);
                clsobj.Msg = "Successfully Inserted";
                return RedirectToAction("AdminHome", "Login");
            }
            return RedirectToAction("AdminHome", clsobj);
        }
    }
    

    
}

 

