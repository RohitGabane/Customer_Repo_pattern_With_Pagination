using Customer_Repo_Pattern.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeDepartment
{
    [Key]
    public int DepartmentId { get; set; } // Auto-incremented key for department ID (Primary Key)

    [MaxLength(100)]
    public string DepartmentName { get; set; } // String with a maximum length of 100 characters.

    public string DepartmentLocation { get; set; } // Additional property: Department's location

    public string DepartmentManager { get; set; } // Additional property: Department manager's name

    // Navigation Property
    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } // Department may have many employees
}
