using EmployeeDirectory.Common;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeesService EmployeesService;
        public EmployeesController() 
        {
            this.EmployeesService = new EmployeesService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = EmployeesService.GetAll();
            if (employees == null)
            {
                return NotFound(Constants.EmployeesNotAdded);
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = EmployeesService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(Constants.EmployeesNotFound);
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            EmployeesService.Create(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id != updatedEmployee.Id)
            {
                return BadRequest(Constants.EmployeeNotMatched);
            }

            EmployeesService.Update(updatedEmployee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            EmployeesService.Delete(id);
            return NoContent();
        }

    }
}
