using Demo3_CRUD.Models;
using Demo3_CRUD.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Demo3_CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var Students = StudentRepository.GetStudents();
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
                return new HttpStatusCodeResult(404, "Id Must Have A Value");
            Student std = StudentRepository.GetStudentDetails(id.Value);
            if (std is null)
                return HttpNotFound("Family Member Doesn't Exsist");
            else
                return View(std);
        }

        public ActionResult Edit(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Id Must Have Avalue");

            else if (StudentRepository.GetStudents().Contains(StudentRepository.GetStudentDetails(id.Value)))
            {
                Student Std = StudentRepository.GetStudentDetails(id.Value);
                return View(Std);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The Member Not Found");
        }


        [HttpPost] //Action Selector
        public ActionResult Edit(Student Std)
        {
            StudentRepository.UpdateStudent(Std);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "id must have avalue");
            else if (StudentRepository.GetStudents().Contains(StudentRepository.GetStudentDetails(id.Value)))
            {
                Student Std = StudentRepository.GetStudentDetails(id.Value);
                //StudentRepository.DelStudent(id.Value);
                //return RedirectToAction(nameof(Index));
                return View(Std);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The Member Not Found");
        }

       // Delete View With Get view
        public ActionResult DeleteStd(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "id must have avalue");
            else if (StudentRepository.GetStudents().Contains(StudentRepository.GetStudentDetails(id.Value)))
            {
                Student Std = StudentRepository.GetStudentDetails(id.Value);
                StudentRepository.DelStudent(id.Value);
                return RedirectToAction(nameof(Index));
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The Member Not Found");
        }
        [HttpPost]
        [ActionName(nameof(Delete))]  //Alias Name
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "id must have avalue");
            else if (StudentRepository.GetStudents().Contains(StudentRepository.GetStudentDetails(id.Value)))
            {
                Student Std = StudentRepository.GetStudentDetails(id.Value);
                StudentRepository.DelStudent(id.Value);
                return RedirectToAction(nameof(Index));
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The Member Not Found");
        }
    }
}