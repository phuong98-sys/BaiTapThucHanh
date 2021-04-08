//using EmployeeQualification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using TestWeb.Models;
using System.Data.Entity;
using System.Dynamic;

namespace TestWeb.Controllers
{
    public class EmployeesController : Controller
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
                    model = model.OrderBy(s => s.LastName);
                    break;
                default:
                    model = model.OrderBy(s => s.FirstName);
                    break;
            }


            int pageSize = 5;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Employee> employee = null;


            employee = model.ToPagedList(pageIndex, pageSize);
            //ViewBag.Message = "Form submitted.";
            return View(employee);
        }

        public ActionResult Add([Bind(Include = "FirstName,MiddleName,LastName,Gender,BirthDate,Email,Note")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);

                context.SaveChanges();

                ViewBag.Success = "Add Employee Susscess!";
                ViewBag.isValid = true;

                return RedirectToAction("Index");
            }
            //if(employee.FirstName==""|| employee.LastName=="" || employee.BirthDate = "")
            //{
            else
            {
                ViewBag.isValid = false;
                //ViewBag.Fail = "Add Employee Fail!";
                //ViewBag.Success = "Add Employee Susscess!";

                //ModelState.AddModelError("", "add employee fail!");
            }

            //ViewBag.MaNSX = new SelectList(db.NHASANXUAT, "MaNSX", "TenNSX", mATHANG.MaNSX);
            return View(employee);
        }


        public ActionResult Edit(Employee model, int id, string firstName, string lastName, DateTime birthDate, int? page)
        {

            ViewBag.firstName = model.FirstName;
            ViewBag.lastName = model.LastName;
            ViewBag.birthDate = model.BirthDate;

            ViewBag.id = id;
            //ViewBag.birthDate = birthDate;

            if (ModelState.IsValid)
            {
                //var e = new Employee();
                Employee e = context.Employees.Find(id);
                e.FirstName = model.FirstName;
                e.MiddleName = model.MiddleName;
                e.LastName = model.LastName;
                e.Gender = model.Gender;
                e.BirthDate = model.BirthDate;
                e.Email = model.Email;
                e.Note = model.Note;
                //context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
                //mymodel.employee = employee;
                ViewBag.Success = "Edit Employee Susscess!";
                //return RedirectToAction("Index");
            }



            var employeeQualifications = context.EmployeeQualifications.Where(m => m.Id != null);
            var qualifications = context.Qualifications.Where(m => m.Id != null);
            //var model2 = context.EmployeeQualifications.Where(m => m.Id != null);
            var model2 = (from eq in employeeQualifications
                          join q in qualifications on eq.QualificationId equals q.Id
                          where eq.EmployeeId == id
                          select new ListQualification()
                          {
                              EmployeeId = eq.EmployeeId,
                              Name = q.Name,
                              City = eq.City,
                              Institution = eq.Institution,
                              ValidFrom = eq.ValidFrom,
                              ValidTo = eq.ValidTo
                              
                          }).OrderBy(x => x.EmployeeId).ToList();
            //model2 = model2.OrderBy(s => s.Id);
            
            int pageSize = 5;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ListQualification> employeeQualification = null;


            employeeQualification = model2.ToPagedList(pageIndex, pageSize);


            //viewbag.message = "form submitted.";
            return View(employeeQualification);

            //return View();
        }

        public ActionResult RemoveLine(int id)
        {
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}