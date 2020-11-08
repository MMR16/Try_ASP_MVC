using Demo.Models;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResultBase Index(string fname, string lname, int id)
        {
            var x = HttpContext.Request.ContentEncoding.BodyName;
            HttpContext.Response.Write("<h1>" + HttpContext.Response.StatusCode + "</h1>");
            ViewData["firstname"] = fname;
            ViewBag.lastname = lname;
            ViewBag.resp = x;
            int age = 60;
            return View(age);
        }

        public ViewResultBase SayHello()
        {

            return View("~/views/home/view2.cshtml");
        }


        public ViewResultBase Student_Department()
        {
            var std = new Student() { Age = 26, LName = "Mahmoud", Salary = 6300.88m };
            var dept = new Department() { Id = 1, Name = "FullStack" };
            var model = new Student_DepartmentViewModel() {student=std,department=dept };
            return View(model);
        }
    }
}