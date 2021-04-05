//using EmployeeQualification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EmployeeQualification.Models;
using System.Data.Entity;

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
            //ViewBag.Message = "Form submitted.";
            return View(eployee);
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

                //}
            //}
            //else
            //{
            //    if (ModelState.IsValid)
            //    {
            //        context.Entry(employee).State = EntityState.Modified;
                    

            //        context.SaveChanges();

            //        ViewBag.Success = "Edit Employee Susscess!";
            //        ViewBag.isValid = true;

            //        return RedirectToAction("Index");
            //    }
            //    //if(employee.FirstName==""|| employee.LastName=="" || employee.BirthDate = "")
            //    //{
            //    else
            //    {
            //        ViewBag.isValid = false;
            //        //ViewBag.Fail = "Add Employee Fail!";
            //        //ViewBag.Success = "Add Employee Susscess!";

            //        //ModelState.AddModelError("", "add employee fail!");
                   
            //    }
            //}





            //ViewBag.MaNSX = new SelectList(db.NHASANXUAT, "MaNSX", "TenNSX", mATHANG.MaNSX);
            return View(employee);
        }
        //public void UpdateItem(Employee e, string firstName, string lastName, string gender, DateTime birthDate)
        //{
        //    CartItem line = lineCollection
        //        .Where(p => p.Sanpham.MaQA == sp.MaQA)
        //        .FirstOrDefault();

        //    if (line != null)
        //    {
              
        //            line.Quantity = quantity;
               
        //    }
        //}
        public ActionResult Edit(int id, string firstName, string lastName, string gender)
        {

            ViewBag.firstName = firstName;
            ViewBag.lastName = lastName;
            ViewBag.gender = gender;
            //ViewBag.birthDate = birthDate;


            var model = context.Employees.Where(m => m.Id != null);

            Employee employee = context.Employees.Find(id);
            //Employee line = model
            //    .Where(p => p.Id == id)
            //    .FirstOrDefault();

            if (employee != null)
            {
                employee.FirstName = firstName;
                employee.LastName = lastName;

                 context.SaveChanges();
                return View("Index");
            }
           

            




            //if (ModelState.IsValid)
            //{
            //    context.Entry(employee).State = EntityState.Modified;


            //    context.SaveChanges();

            //    ViewBag.Success = "Edit Employee Susscess!";
            //    ViewBag.isValid = true;

            //    return RedirectToAction("Index");
            //}
            ////if(employee.FirstName==""|| employee.LastName=="" || employee.BirthDate = "")
            ////{
            //else
            //{
            //    ViewBag.isValid = false;
            //    //ViewBag.Fail = "Add Employee Fail!";
            //    //ViewBag.Success = "Add Employee Susscess!";

            //    //ModelState.AddModelError("", "add employee fail!");

            //}
            //if (ModelState.IsValid)
            //{
            //    context.Employees.Add(employee);

            //    context.SaveChanges();

            //    ViewBag.Success = "Add Employee Susscess!";
            //    ViewBag.isValid = true;

            //    return RedirectToAction("Index");
            //}
            ////if(employee.FirstName==""|| employee.LastName=="" || employee.BirthDate = "")
            ////{
            //else
            //{
            //    ViewBag.isValid = false;
            //    //ViewBag.Fail = "Add Employee Fail!";
            //    //ViewBag.Success = "Add Employee Susscess!";

            //    //ModelState.AddModelError("", "add employee fail!");
            //}

            ////}




            ////ViewBag.MaNSX = new SelectList(db.NHASANXUAT, "MaNSX", "TenNSX", mATHANG.MaNSX);
            return View(employee);
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