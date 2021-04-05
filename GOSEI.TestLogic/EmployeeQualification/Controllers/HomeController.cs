//using EmployeeQualification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EmployeeQualification.Models;

namespace EmployeeQualification.Controllers
{
    public class HomeController : Controller
    {
        MyContext context = new MyContext();
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //ViewBag.Id = String.IsNullOrEmpty(sort_Order) ? "Id" : "";
            //ViewBag.FirstName = String.IsNullOrEmpty(sort_Order) ? "FirstName" : "";
            //ViewBag.LastName = String.IsNullOrEmpty(sort_Order) ? "LastName" : "";
            //if (page == null) page = 1;
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
        
            var model = context.Employees.Where(m => m.Id != null);


            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }
            switch (sortOrder)
                {
                    case "FirstName":
                        model = model.OrderByDescending(s => s.FirstName);
                        break;
                    case "LastName":
                        model = model.OrderByDescending(s => s.LastName);
                        break;
                    default:
                        model = model.OrderBy(s => s.Id);
                        break;
                }
        

            int pageSize = 5;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList < Employee> eployee = null;

           
            eployee = model.ToPagedList(pageIndex, pageSize);

         


            return View(eployee);
        }
        public ActionResult Add(Employee model)
        {
            var user = new Employee();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Note = model.Note;
          
            var result = context.Employees.Add(user);
            if (result != null)
            {
                ViewBag.Success = " Thêm thành công";
                model = new Employee();

            }
            else
            {
                ModelState.AddModelError("", " Thêm thất bại");

            }
            context.SaveChanges();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult RemoveLine(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}