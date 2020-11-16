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
    ////////////////////////////////route attibutes MVC 5
    //routes Controller 
    //to go to any action with sigment start with MMR
    //except the action using route like index to go to it we use localhost/in or localhost or localhost/f/in
    //[Route("MMR/{action}/{id?}")]  //id is optional
    //  [Route("MMR/{action}/{id:string}")] //id is string 
    //[Route("MMR/{action}/{id:range(1,7)}")] //id -> int64 & range is 1 to 7
    public class StudentController : Controller
    {
        // GET: Student
        //route over Action
        //[Route("",Order = 3)]
        //[Route("IN",Order=2)]
        //[Route("F/IN", Order = 1)]

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
            //  if (!ModelState.IsValid)
            //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Enter Valid Data");
            if (ModelState.IsValid)
            {
                    StudentRepository.AddStudent(student);
                    return RedirectToAction(nameof(Index)); //nameof return the name of any thing as string
            }
            //return RedirectToAction("Index");
            // return View("Index",StudentRepository.GetStudents());
            return View(student);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Must Have Avalue");

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
            if (ModelState.IsValid)
            {
                StudentRepository.UpdateStudent(Std);
                return RedirectToAction(nameof(Index));
            }
            else return View(Std);
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
        public ActionResult CheckID(int Id,string FName)
        {
            //var std=StudentRepository.GetStudents().FirstOrDefault(a => a.Id == Id);
            //     if (std is null)
            //     {
            //         return Json(true, JsonRequestBehavior.AllowGet);
            //     }
            //     return Json(false, JsonRequestBehavior.AllowGet);

            return Json(!(StudentRepository.GetStudents().Any(ww => ww.Id== Id) && StudentRepository.GetStudents().Any(ww => ww.FName == FName)), JsonRequestBehavior.AllowGet);
        }

    }
}