using DataFromViewToController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataFromViewToController.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string PostUsingParameters(string firstName, string lastName)
        {
            return "From parameters -"+firstName+" "+lastName;
        }
        [HttpPost]
        public string GetUsingParameters()
        {
            string firstName = Request["firstName"];
            string lastName = Request["lastName"];
            return "From request -" + firstName + " " + lastName;
        }
        [HttpPost]
        public string PostUsingFormCollection(FormCollection form)
        {
            string firstName = form["firstName"];
            string lastName = form["lastName"];
            return "From form -"+ firstName + " " + lastName;
        }
        public string PostUsingBinding(Employee employee)
        {
            return "From Binding-"+employee.FirstName+" "+employee.LastName;
        }
    }
}