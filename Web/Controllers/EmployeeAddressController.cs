using Domain.Dtos.EmployeeAddress;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeAddressController : ControllerBase
{
    private readonly EmployeeAddressService _emploeeAddressService;

    public EmployeeAddressController(EmployeeAddressService emploeeAddressService)
    {
        _emploeeAddressService = emploeeAddressService;
    }

    [HttpPost("AddEmployeeAddress")]
    public EmployeeAddressBase AddEmployeeAddress([FromForm]EmployeeAddressBase emploeeAddress)
    {
        return _emploeeAddressService.AddEmployeeAddress(emploeeAddress);
    }

    [HttpPut("UpdateEmployeeAddress")]
    public EmployeeAddressBase UpdateEmployeeAddress([FromForm]EmployeeAddressBase emploeeAddress)
    {
        return _emploeeAddressService.UpdateEmployeeAddress(emploeeAddress);
    }
    [HttpDelete("DeleteEmployeeAddress")]
    public bool DeleteEmployeeAddress(int id)
    {
        return _emploeeAddressService.DeleteEmployeeAddress(id);
    }

    [HttpGet("GetEmployeeAddressById")]
    public EmployeeAddressBase GetEmployeeAddressById(int id)
    {
        return _emploeeAddressService.GetEmployeeAddressById(id);
    }

    [HttpGet("GetEmployeeAddresss")]
    public List<EmployeeAddressBase> GetEmployeeAddresss()
    {
        return _emploeeAddressService.GetEmployeeAddresses();
    }
}