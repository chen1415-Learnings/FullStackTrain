using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Web.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(10)]
        public string DepartmentName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string DepartmentHead { get; set; }

        //Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}