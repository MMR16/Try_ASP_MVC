using Demo3_CRUD.Models;
using Demo3_CRUD.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Demo3_CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
          var Students=  StudentRepository.GetStudents();
            return View(Students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            StudentRepository.AddStudent(student);
            return RedirectToAction(nameof(Index)); //nameof return the name of any thing as string
            //return RedirectToAction("Index");
           // return View("Index",StudentRepository.GetStudents());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(404,"Id Must Have A Value");
            Student std = StudentRepository.GetStudentDetails(id.Value);
            if (std is null)
                return HttpNotFound("Family Member Doesn't Exsist");
            else
            return View(std);
        }

        public ActionResult Edit(int id)
        {
            Student Std = StudentRepository.GetStudentDetails(id);
            if(Std is null)
                return HttpNotFound("Family Member Doesn't Exsist");
                else
            return View(Std);
        }


        [HttpPost] //Action Selector
        public ActionResult Edit(Student Std)
        {
             StudentRepository.UpdateStudent(Std);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            StudentRepository.DelStudent(id);
            return RedirectToAction("Index");
        }

    }
}