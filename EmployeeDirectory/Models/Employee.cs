namespace EmployeeDirectory.Models
{
    public class Employee
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public int Age { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

    }
}
