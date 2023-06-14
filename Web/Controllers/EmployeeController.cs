using Domain.Dtos.Employee;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("AddEmployee")]
    public EmployeeBase AddEmployee([FromForm]EmployeeBase employee)
    {
        return _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmployee")]
    public EmployeeBase UpdateEmployee([FromForm]EmployeeBase employee)
    {
        return _employeeService.UpdateEmployee(employee);
    }
    [HttpDelete("DeleteEmployee")]
    public bool DeleteEmployee(int id)
    {
        return _employeeService.DeleteEmployee(id);
    }

    [HttpGet("GetEmployeeById")]
    public EmployeeBase GetEmployeeById(int id)
    {
        return _employeeService.GetEmployeeById(id);
    }

    [HttpGet("GetEmployees")]
    public List<EmployeeBase> GetEmployees()
    {
        return _employeeService.GetEmployees();
    }
}