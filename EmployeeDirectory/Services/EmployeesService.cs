using EmployeeDirectory.Common;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services
{
    public class EmployeesService
    {

        public void Create(Employee employee)
        {
            employee.Id = employee.Id + 1;
            employee.CreatedOn = DateTime.Now;
            employee.ModifiedOn = DateTime.Now;
            DataStorage.Employees.Add(employee);            
        }

        public void Update(Employee updatedEmployee)
        {
            Employee employee = this.GetEmployeeById(updatedEmployee.Id);
            if(employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Age = updatedEmployee.Age;
                employee.Designation = updatedEmployee.Designation;
                employee.Department = updatedEmployee.Department;
                employee.ModifiedOn = DateTime.Now;
            }
        }

        public void Delete(int employeeId)
        {
            Employee employee = this.GetEmployeeById(employeeId);
            if (employee != null)
            {
                DataStorage.Employees.Remove(employee);
            }
        }

        public List<Employee> GetAll()
        {
            return DataStorage.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = DataStorage.Employees.Find(emp => emp.Id == employeeId);
            return employee; 
        }
    }
}
