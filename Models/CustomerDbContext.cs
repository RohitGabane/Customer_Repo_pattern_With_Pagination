using Microsoft.EntityFrameworkCore;

namespace Customer_Repo_Pattern.Models
{
    public class CustomerDbContext :DbContext
    {
        public CustomerDbContext()
        { 
        }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeesDepartment { get; set; }

    }
}
