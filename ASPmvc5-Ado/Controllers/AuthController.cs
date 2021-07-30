using ASPmvc5_Ado.Models;
using ASPmvc5_Ado.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPmvc5_Ado.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            //return RedirectToAction("GetAllEmpDetails", "Employee");
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AuthRepository AuthRepo = new AuthRepository();
                    if (AuthRepo.Login(User))
                    {
                        Response.Redirect("Employee/GetAllEmpDetails");
                        string output = "Login Success";
                        return Json(output, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string output = "Failed!";
                        return Json(output, JsonRequestBehavior.AllowGet);
                    }
                }
                string output2 = "failed in try";
                return Json(output2, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Auth
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(UserModel User)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            AuthRepository AuthRepo = new AuthRepository();

        //            if (AuthRepo.Register(User))
        //            {
        //                ViewBag.Message = "Registered successfully";
        //            }
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
