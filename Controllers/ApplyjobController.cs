using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class ApplyjobController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();

        // Action for applying to a job - Load job details
        public ActionResult ApplyCV_Load(int jid)
        {
            // Store job ID in TempData
            TempData["jid"] = jid;

            var job = dbobj.JobTabs.FirstOrDefault(j => j.Job_ID == jid);

            // Pass job details to the view
            ViewBag.JobTitle = job?.Job_Title;
            ViewBag.JobDescription = job?.Job_Description;

            return View();
        }

       
       
        public ActionResult ApplyNow(Application application, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the job ID from TempData
                int jobId = Convert.ToInt32(TempData["jid"]);

                if (jobId == 0)
                {
                    // Handle case where job ID is not valid
                    ViewData["ErrorMessage"] = "Invalid Job ID";
                    return View("ApplyCV_Load");
                }

                // Save the resume if uploaded
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Server.MapPath("~/Photos");
                    string fullPath = Path.Combine(filePath, fileName);
                    file.SaveAs(fullPath);  // Save the file to the server

                    // Store the file path for the resume
                    application.Resume = Path.Combine("~\\Photos", fileName);
                }

                // Get the user ID from session
                int userId = Convert.ToInt32(Session["usid"]);
                application.uid = userId;

                // Set the job ID
                application.jid = jobId;

                // Set the application date to the current date
                application.ApplicationDate = DateTime.Now;

                // Set the application status
                application.Status = "Applied";

                // Call the stored procedure to insert the application
                dbobj.sp_InsertApplication(application.uid, application.jid, application.ApplicationDate, application.Resume, application.Status);

                // Display success message
                TempData["SuccessMessage"] = "Successfully Applied";
return RedirectToAction("ApplyCV_Load", new { jid = jobId });
            }

            // If validation failed, stay on the current view
            return View("ApplyCV_Load", application);
        }
    }

}
