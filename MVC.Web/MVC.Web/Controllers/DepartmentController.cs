using MVC.Web.Models;
using MVC.Web.ProjectDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Web.Controllers
{
    public class DepartmentController : Controller
    {

        private DepartmentDbContext _dbContext;

        public DepartmentController()
        {
            _dbContext = new DepartmentDbContext();
        }



        // GET: /Department/Index
        public ActionResult Index()
        {
            List<Department> departments = _dbContext.Departments
                                        .Include("Employees")
                                        .ToList();
            return View(departments);
        }

        // GET: /Department/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception("Please enter s valid department id");
            }
            Department department = _dbContext.Departments
                                              .Include("Employees")
                                              .FirstOrDefault(d => d.ID == id);
            return View(department);
        }


        // GET: /Department/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Please enter s valid department id");
            }
            Department department = _dbContext.Departments
                                              .Include("Employees")
                                              .FirstOrDefault(d => d.ID == id);
            return View(department);
        }

        // POST: /Department/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            //Currently saved record in the DB
            Department departmentInDb = _dbContext.Departments
                                                .Include("Employees")
                                                .FirstOrDefault(d => d.ID == department.ID);
            departmentInDb.DepartmentName = department.DepartmentName;
            departmentInDb.Location = department.Location;
            departmentInDb.DepartmentHead = department.DepartmentHead;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            Department toBeDeleted = _dbContext.Departments.FirstOrDefault(dept => dept.ID == id);

            _dbContext.Departments.Remove(toBeDeleted);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}