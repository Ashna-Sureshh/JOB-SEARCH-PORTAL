using System;
using System.Linq;
using System.Web.Mvc;
using JOBSEARCHPORTAL.Models;

namespace JOBSEARCHPORTAL.Controllers
{
    public class LoginController : Controller
    {
        JobSearchPortalDBEntities1 dbobj = new JobSearchPortalDBEntities1();

        // GET: Login
        public ActionResult Login_pageload()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        // POST: Handle Login

        public ActionResult Login_click(Loginclass clsobj)
        {
            var val = dbobj.sp_loginCountId(clsobj.uname, clsobj.pswd).Single();
            if (val == 1)
            {
                var uid = dbobj.sp_loginId(clsobj.uname, clsobj.pswd).FirstOrDefault();
                Session["usid"] = uid;
                var lt = dbobj.sp_logtype(clsobj.uname, clsobj.pswd).FirstOrDefault();
                if (lt == "User")
                {
                    return RedirectToAction("UserHome");
                }
                else if (lt == "Company")
                {
                    return RedirectToAction("AdminHome");
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid Login";
                return View("Login_pageload", clsobj);
            }
            return View("Login_pageload", clsobj);
        }

    }

}
