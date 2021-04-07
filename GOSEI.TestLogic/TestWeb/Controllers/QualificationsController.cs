﻿using System;
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
        public ActionResult Add(TestWeb.Models.EmployeeQualification model, int id)
        {

            if (ModelState.IsValid)
            {
                //var e = new Employee();
                TestWeb.Models.EmployeeQualification e = new TestWeb.Models.EmployeeQualification();
                e.QualificationId = model.QualificationId;
                e.EmployeeId = id;
                e.Note = model.Note;
                context.EmployeeQualifications.Add(e);

                //context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
                //mymodel.employee = employee;
                ViewBag.Success = "Add eq Susscess!";
                return RedirectToAction("Index");
            }

           
            ViewBag.qualificationId = new SelectList(context.Qualifications, "Id", "Name", model.QualificationId);
            //else
            //{
            //    ViewBag.isValid = false;
            //}

          
            return View(model);
        }
    }
}