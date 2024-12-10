

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class UserRegController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();
        // GET: UserReg
        public ActionResult Insertuser_Pageload()
        {
            return View();
        }
        public ActionResult Insertuser_Click(UserRegclass clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.Photo = fullpath;
                }
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
                dbobj.sp_useReg(regid, clsobj.Name, clsobj.Age, clsobj.Address, clsobj.Phone, clsobj.Email, clsobj.Skills, clsobj.Experience, clsobj.Location, clsobj.Photo, clsobj.Qualification, clsobj.Preferences);
                dbobj.sp_loginsert(regid, clsobj.Username, clsobj.Password, "User");
                TempData["Success"] = "User has been successfully registered.";
                // Clear the form fields
                ModelState.Clear();
                clsobj = new UserRegclass(); // Reset the object to clear fields
                return View("Insertuser_Pageload", clsobj);

            }
            return View("Insertuser_Pageload", clsobj);
        }
    }
}
