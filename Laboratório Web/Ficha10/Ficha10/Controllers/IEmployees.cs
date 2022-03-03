namespace Ficha10.Controllers
{
    public interface IEmployees
    {
        IEnumerable<Employee> EmployeesList { get; }
    }
}