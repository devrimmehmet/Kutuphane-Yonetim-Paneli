using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        {
            var values = db.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeAdd");
            }
            db.Employees.Add(employees);
            db.SaveChanges();
            return View();
        }
        public ActionResult EmployeeDelete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeGet(int id)
        {
            var employee = db.Employees.Find(id);
            return View("EmployeeGet", employee);
        }
        public ActionResult EmployeeUpdate(Employees e)
        {
            

            var _employee = db.Employees.Find(e.Id);
            _employee.Employee = e.Employee;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}