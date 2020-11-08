using Demo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        //Model Binder
        //1- Form Data     //post method
        //2- Route Data    //controller/action/id
        //3- Query String  //get method
        public ActionResult Welcome(Register Person, Register Department)
        {
            //used with Get
            //var QS1 = HttpContext.Request.QueryString["fname"];
            //var QS2 = HttpContext.Request.QueryString["lname"];
            //var QS3 =int.Parse(HttpContext.Request.QueryString["id"]);
            //var QS4 =int.Parse(HttpContext.Request.QueryString["Age"]);

            //used with Post
            //var Form1 = HttpContext.Request.Form["fname"];
            //var Form2 = HttpContext.Request.Form["lname"];
            //var Form3 = int.Parse(HttpContext.Request.Form["id"]);
            //var Form4 = int.Parse(HttpContext.Request.Form["Age"]);

            //Routing System /Home/index/id
            // var RD= RouteData.Values["id"].ToString();

            ViewBag.deptid = Department.DeptId;
            ViewBag.deptname = Department.DeptName;
            ViewBag.deptdesc = Department.Desc;

            return View(Person);
        }

        public ActionResult Show()
        {

            return View();
        }

        //using array & Dictionary
        public ActionResult Display(int[] dept, Dictionary<string, int> D1)
        {
            int mmr;
            if (dept.Length >= 2)
            {
                ViewBag.mostafa = D1["Mostafa"];
                ViewBag.ahmed = D1["Ahmed"];
                ViewBag.alaa = D1["Alaa"];
                return View(dept);

            }
            else
               return RedirectToAction(actionName:"show");
               // return View("~/views/home/show.cshtml");
        }
    }
}