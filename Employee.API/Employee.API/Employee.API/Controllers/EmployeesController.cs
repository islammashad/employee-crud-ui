using Employee.API.Data;
using Employee.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDBContext _employeeDBContext;
        public EmployeesController(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeDBContext.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeEntity employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            _employeeDBContext.Employees.Add(employeeRequest);
            await _employeeDBContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, EmployeeEntity updateEmployeeRequest)
        {
            var employee = await _employeeDBContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Department = updateEmployeeRequest.Department;
            employee.Email = updateEmployeeRequest.Email;

            await _employeeDBContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task <IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeDBContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _employeeDBContext.Employees.Remove(employee);
            await _employeeDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}
