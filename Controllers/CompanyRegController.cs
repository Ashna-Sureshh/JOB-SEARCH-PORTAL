using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class CompanyRegController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();
        // GET: CompanyReg
        public ActionResult Insertcompany_Pageload()
        {
            return View();
        }
        public ActionResult Insertcompany_Click(CompanyRegclass clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_companyReg(regid, clsobj.CompanyName, clsobj.CompanyAddress, clsobj.CompanyEmail, clsobj.CompanyWebsite, clsobj.Company_Phone);
                dbobj.sp_loginsert(regid, clsobj.Username, clsobj.Password, "Company");
                TempData["Success"] = "Company successfully registered!";
                // Clear ModelState and reset form
                ModelState.Clear();
                clsobj = new CompanyRegclass();
                return View("Insertcompany_Pageload", clsobj);

            }
            return View("Insertcompany_Pageload", clsobj);

        }
    }
}
