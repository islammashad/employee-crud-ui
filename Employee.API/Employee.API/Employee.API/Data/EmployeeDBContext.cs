using Employee.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
             
        }      
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
