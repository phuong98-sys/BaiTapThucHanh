using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace EmployeeQualification.Controllers
{
    public class QualificationsController : Controller
    {
        // GET: Qualifications
        MyContext context = new MyContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(TestWeb.Models.EmployeeQualification model, int id ,string firstName, string middleName, string lastName, DateTime birthDate,string submit)
        {
            ViewBag.Id = id;
            ViewBag.firstName = firstName;
            ViewBag.middleName = middleName;
            ViewBag.lastName = lastName;
            ViewBag.birthDate = birthDate.ToString("yyyy-MM-dd");
            ViewBag.submit = submit;
            if (submit!=null)
            {
                TestWeb.Models.EmployeeQualification e = new TestWeb.Models.EmployeeQualification();
                e.QualificationId = model.QualificationId;
                e.EmployeeId = id;
                e.Note = model.Note;
                e.Institution = model.Institution;
                e.ValidFrom = model.ValidFrom;
                e.ValidTo = model.ValidTo;
                e.City = model.City;
                context.EmployeeQualifications.Add(e);
                context.SaveChanges();
                return RedirectToAction("Index","Employees");
            }
            // Hiển thj ra Name của tất cả Qualification trong hệ thống
            SelectList cateList = new SelectList(context.Qualifications, "Id", "Name", model.QualificationId);
            ViewBag.qualificationId = cateList;
            return View(model);
        }
    }
}