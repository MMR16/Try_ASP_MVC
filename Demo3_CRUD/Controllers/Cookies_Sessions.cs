using Demo3_CRUD.Models;
using Demo3_CRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo3_CRUD.Controllers
{
    public class Cookies_SessionsController : Controller
    {
        //Usual Way To Send Data From Action To Another IS: ViewBag,ViewData,TempData,Model
        //By Sending The Action Data To View Then Send It From The View To Any Other Actions(Like What We Do In Index & Details)

        //To Send Data From Action To Any Other Actions Without Passin By View We Use: Cookies & Sessions

        public ActionResult Index(int i)
        {
            string Name = "Mostafa";
            String Pass = "12345";
            ViewBag.Name = Name;
            ViewBag.Pass = Pass;

            People P1 = new People() { Id = 1, Fname = "Mostafa", LName = "Mahmoud" };

            #region Cookies
            //Cookies
            //client side //memory
            //Can't Take Object
            //key value pair
            //not recommended for sensitive Informations
            //client can change values of cookies
            HttpCookie HC = new HttpCookie("Login");
            HC.Values["name"] = Name;
            HC.Values["pass"] = Pass;
            //HC.Values["P"] = P1;        //Can't Take Object
            //HC.Secure=true;
            HC.Expires = DateTime.Now.AddMinutes(1);    //to set time expiration of cookies
            HttpContext.Response.Cookies.Add(HC);
            #endregion

            #region Sessions
            //Server Side
            //More Secure
            //Save Session ID Only on Client Cookies
            //The Session it self Stored on the Server With acopy of Session ID from Client
            //Every request The IIS Compare the Two Id From IIS Server & Session ID Only on Client Cookies
            //if the same it will work well
            //Session Expiration 20 Minutes Only Can Inscrease By Session.Timeout = 100;
            Session["N"] = Name;
            Session["p"] = Pass;
            Session["Id"] = i;
            Session["Person"] = P1;
            #endregion



            return View();
        }
        public ActionResult Details(string Name, string PassWord)
        {
            string[] A = new string[] { Name, PassWord };
            return View(A);
        }

        public ActionResult Cookie()
        {
            var s = HttpContext.Request.Cookies["Login"];
            string N = s.Values["Name"];
            string P = s.Values["Pass"];
            //tempdata can access it's value one time only
            TempData["NN"] = N;
            TempData["PP"] = P;
            return View(s);
        }

        public ActionResult Cookies()
        {
            var C = HttpContext.Request.Cookies["login"];
            return View(C);
        }

        public ActionResult Session1()
        {
            var details = Session["Person"];
            var name = Session["N"];
            var PassWord = Session["P"];
            ViewData["FirstName"] = name;
            ViewData["PassWord"] = PassWord;

            return View(details);
        }

        public ActionResult Session2()
        {
            var I = Session.SessionID;
            // gets or sets the time, in minutes, that can
            // elapse between requests before the session-state provider ends the session.
            // Session.Timeout = 100;  //Minutes
            var T = Session.Timeout;
            ViewBag.ID = I;
            ViewBag.Time = T;
            ViewBag.Id = Session["Id"];

            var S = Session["Person"] as People; //Casting Because the return is Object
            return View(S);
        }

    }
}