using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Models;

namespace TestWeb.ViewModel
{
    public class DetailViewModel
    {
        public Employee Employee { get; set; }
        public IPagedList<TestWeb.Models.EmployeeQualification> EmployeeQualification { get; set; }
    }
}