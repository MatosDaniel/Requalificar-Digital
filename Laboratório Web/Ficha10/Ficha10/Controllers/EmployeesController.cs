using Ficha10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

namespace Ficha10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private Employees employees;

        public EmployeesController()
        {
            employees = JsonLoader.LoadEmployeesJson();
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees.EmployeesList;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Employee employee)
        {
            if(employees.EmployeesList.Count == 0)
            {
                employee.UserId = 1;
                employees.EmployeesList.Add(employee);
            }
            else
            {
                var lastEmp = employees.EmployeesList[employees.EmployeesList.Count - 1];
                employee.UserId = lastEmp.UserId + 1;
                employees.EmployeesList.Add(employee);
            }

            return Ok(employee);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var remove = employees.EmployeesList.RemoveAll(e => e.UserId == id);
            if(remove == 0)
            {
                return NotFound($"ID: {id} not found!");
            }
            else
            {
                return Ok($"ID: {id} was removed!");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var emp = employees.EmployeesList.Find(e => e.UserId == id);
            if (emp == null)
            {
                return NotFound($"ID: {id} not found.");
            }
            else
            {
                return Ok(emp);
            }
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var emp = employees.EmployeesList.Find(e=> e.UserId == id);
            if (emp == null)
            {
                return NotFound($"ID: {id} not found!");
            }
            else
            { 
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Region = employee.Region;
                emp.EmployeeCode = employee.EmployeeCode;
                emp.JobTitle = employee.JobTitle;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.EmailAddress = employee.EmailAddress;

                return Ok(emp);
            }
        }
        
        [HttpGet("region/{region}", Name = "GetByRegion")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string region)
        {
            Employee? emp = employees.EmployeesList.Find(e=> e.Region == region);
            if(emp == null)
            {
                return NotFound($"Não foi encontrado ninguem de {region}");
            }
            else
            {
                return Ok(emp);
            }
        }

        
        [HttpGet("download", Name = "GetDownload")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Download()
        {
            string jsonAllEmps = JsonSerializer.Serialize(employees);
            System.IO.File.WriteAllText("JsonFiles/allEmps.json", jsonAllEmps);

            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes("JsonFiles/allEmps.json");
                return File(bytes, "application/json", "JsonFiles/employees.json");
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
        } 
    }
}