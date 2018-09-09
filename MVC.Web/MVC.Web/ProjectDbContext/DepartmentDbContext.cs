using MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Web.ProjectDbContext
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext()
            :base("DefaultConnectionString")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}