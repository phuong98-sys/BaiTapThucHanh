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
using System.Globalization;

namespace TestWeb.Controllers
{
    public class EmployeesController : Controller
    {
        MyContext context = new MyContext();
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var model = context.Employees.Where(m => m.Id != null);
            if (!String.IsNullOrEmpty(searchString))
            {
                //Tìm kiếm theo lastName và firstName
                model = model.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }
            //Sắp xếp list Employee theo firstName và LastName
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
            int pageSize = 5; // số bản ghi của 1 trang
            int pageIndex = 1; // chỉ số trang

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Employee> employee = null;


            employee = model.ToPagedList(pageIndex, pageSize);
            return View(employee);
        }

        public ActionResult Add([Bind(Include = "FirstName,MiddleName,LastName,Gender,Email,BirthDate,Email,Note")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

       
        public ActionResult Edit(Employee model, TestWeb.Models.EmployeeQualification modelQ, int id, string firstName,string middleName, string lastName, DateTime birthDate, string email, string note,int? page, string submit,string submit2)
        {
   
            ViewBag.firstName = firstName;
            ViewBag.middleName = middleName;
            ViewBag.lastName = lastName;
            ViewBag.fullName = firstName + " " + middleName + " " + lastName; // tạo full Name cho employee
            ViewBag.birthDate = birthDate.ToString("yyyy-MM-dd");
            ViewBag.page = page;
            ViewBag.id = id;
            ViewBag.email = email;
            ViewBag.note = note;

            ViewBag.isValid = false;
            if (submit !=null)
            {
                // Lưu thông tin mới của employee
                Employee e = context.Employees.Find(id);
                e.FirstName = model.FirstName;
                e.MiddleName = model.MiddleName;
                e.LastName = model.LastName;
                e.Gender = model.Gender;
                e.BirthDate = model.BirthDate;
                e.Email = model.Email;
                e.Note = model.Note;
                context.SaveChanges();
                ViewBag.isValid = true;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.isValid = false;
            }
          
            var employeeQualifications = context.EmployeeQualifications.Where(m => m.Id != null);
            var qualifications = context.Qualifications.Where(m => m.Id != null);
            //Hiển thị list Qualifications của Employee có mã == id
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

            int pageSize = 5;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ListQualification> employeeQualification = null;
            employeeQualification = model2.ToPagedList(pageIndex, pageSize);

            //Thêm mới Qualification cho Employee có mã =id
            if (submit2 != null)
            {
                TestWeb.Models.EmployeeQualification e = new TestWeb.Models.EmployeeQualification();
                e.QualificationId = modelQ.QualificationId;
                e.EmployeeId = modelQ.EmployeeId;
                e.Note = modelQ.Note;
                e.Institution = modelQ.Institution;
                e.ValidFrom = modelQ.ValidFrom;
                e.ValidTo = modelQ.ValidTo;
                e.City = modelQ.City;
                context.EmployeeQualifications.Add(e);
                context.SaveChanges();
             
            }
            // Hiển thj ra Name của tất cả Qualification trong hệ thống
            SelectList cateList = new SelectList(context.Qualifications, "Id", "Name", modelQ.QualificationId);
            ViewBag.qualificationId = cateList;
            return View(employeeQualification);
        }
       
        public ActionResult RemoveLine(int id)
        {
            //Xóa list Qualifications của employee có mã =id
            var model = context.EmployeeQualifications.Where(m => m.EmployeeId ==id).ToList();
            foreach( var item in model)
            {

                context.EmployeeQualifications.Remove(item);
            
            }
            // Xóa nhân viên có mã =id
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    //public void AddQ(TestWeb.Models.EmployeeQualification model, string submit2)
    //{
    //    ViewBag.firstName  = Request["FirstName"].ToString();
    //    ViewBag.lastName = Request["LastName"].ToString();
    //    ViewBag.middleName = Request["MiddleName"].ToString();
    //    ViewBag.gender = Request["Gender"].ToString();
    //    ViewBag.email = Request["Email"].ToString();
    //    ViewBag.birthDate = Request["BirthDate"].ToString();
    //    ViewBag.note = Request["Note"].ToString();
    //    if (submit2 != null)
    //    {
    //        TestWeb.Models.EmployeeQualification e = new TestWeb.Models.EmployeeQualification();
    //        e.QualificationId = model.QualificationId;
    //        e.EmployeeId = model.EmployeeId;
    //        e.Note = model.Note;
    //        e.Institution = model.Institution;
    //        e.ValidFrom = model.ValidFrom;
    //        e.ValidTo = model.ValidTo;
    //        e.City = model.City;

    //        context.EmployeeQualifications.Add(e);
    //        context.SaveChanges();

    //    }
    //    // Hiển thj ra Name của tất cả Qualification trong hệ thống
    //    SelectList cateList = new SelectList(context.Qualifications, "Id", "Name", model.QualificationId);
    //    ViewBag.qualificationId = cateList;

    //    //return RedirectToAction("Edit", "Employees",new {id= model.EmployeeId, firstName=ViewBag.firstname, middleName = ViewBag.MiddleName, lastName = ViewBag.lastName,note=ViewBag.note, email=ViewBag.email,  birthDate = ViewBag.birthDate });
    //}
}