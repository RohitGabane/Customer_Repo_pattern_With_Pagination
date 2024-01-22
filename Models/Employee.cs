using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer_Repo_Pattern.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; } // Auto-incremented key for employee ID (Primary Key)

        [MaxLength(100)]
        public string EmpName { get; set; } 

        public string EmpAddress { get; set; } 

        [Column(TypeName = "decimal(18,2)")]
        public decimal EmpSalary { get; set; } 

        public DateTime EmpJoinDate { get; set; } 

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        [ForeignKey("DepartmentId")]
        public virtual EmployeeDepartment Department { get; set; }
    }
}
