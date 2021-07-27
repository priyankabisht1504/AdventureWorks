using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Helper;

namespace AdventureWorks.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentBAL departmentBal;

        public DepartmentController()
        {
            departmentBal = departmentBal ?? new DepartmentBAL();
        }
        // GET: Department
        public ActionResult Index(string SortOrder,string SortBy,int PageNumber = 1)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            ViewBag.PageNumber = PageNumber;
            var DepartmentList = departmentBal.GetAllDepartment();
            
            ViewBag.TotolCount = DepartmentList.Count();
            ViewBag.TotalPage = Math.Ceiling(DepartmentList.Count() / 5.0);
            DepartmentList = DepartmentList.Skip((PageNumber - 1)*5).Take(5).ToList();

            return View(DepartmentList);
        }

        public ActionResult Add()
        {
            //var DepartmentList = departmentBal.GetAllDepartment();
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                var result = departmentBal.AddDepartment(department);
            }
            return RedirectToAction("Index");
        }
         
       
        public ActionResult Edit(int DepartmentId)
        {
            var departmentDetails = departmentBal.GetDepartmentById(DepartmentId);
            return PartialView(departmentDetails);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                var result = departmentBal.UpdateDepartment(department);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int DepartmentId)
        {
            var result = departmentBal.DeleteDepartment(DepartmentId);
            return RedirectToAction("Index");
        }
    }
}