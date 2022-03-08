using Ficha10.Models;

namespace Ficha10.Models
{
    public class Employees : IEmployees
    {
        private List<Employee> employeesList;

        List<Employee> IEmployees.EmployeesList
        {
            get => employeesList;
            set => employeesList = value;
        }

        public Employees()
        {
            employeesList = JsonLoader.LoadEmployeesJson();
        }


    }
}