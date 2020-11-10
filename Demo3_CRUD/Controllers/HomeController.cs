using Demo3_CRUD.Models;
using Demo3_CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo3_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // The return From ActionResult
        public ActionResult Index(int id)
        {
            if (id == 1)
                return View();
            ////return new ViewResult() { ViewName = "Index" };
            else if (id == 2)
                return HttpNotFound("Student Doesn't Exist");
            else if (id >= 3 && id <= 5)
                return File(Server.MapPath($"~/MyFiles/{id}.txt"), "text/plain", $"MyFile N 0{id}.txt");
            else if (id == 6)
                return Redirect("https://www.google.com?q=ASP");
            else if (id == 7)
                //  return Json(new Student() {Id=2,FName="Mostafa",LName="Mahmoud",Age=26 },JsonRequestBehavior.AllowGet);
                return Json(StudentRepository.GetStudents(),JsonRequestBehavior.AllowGet);
            else
                return Content("index");
            //return new ContentResult() { Content = "Index" };
        }

        public ActionResult Show()
        {
            return View();
        }


        public string Str(string id)
        {
            return id;
        }



    }
}