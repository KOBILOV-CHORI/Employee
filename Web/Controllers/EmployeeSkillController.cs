using Domain.Dtos.EmployeeSkill;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeSkillController : ControllerBase
{
    private readonly EmployeeSkillService _demployeeSkillService;

    public EmployeeSkillController(EmployeeSkillService demployeeSkillService)
    {
        _demployeeSkillService = demployeeSkillService;
    }

    [HttpPost("AddEmployeeSkill")]
    public EmployeeSkillBase AddEmployeeSkill([FromForm]EmployeeSkillBase demployeeSkill)
    {
        return _demployeeSkillService.AddEmployeeSkill(demployeeSkill);
    }

    [HttpPut("UpdateEmployeeSkill")]
    public EmployeeSkillBase UpdateEmployeeSkill([FromForm]EmployeeSkillBase demployeeSkill)
    {
        return _demployeeSkillService.UpdateEmployeeSkill(demployeeSkill);
    }
    [HttpDelete("DeleteEmployeeSkill")]
    public bool DeleteEmployeeSkill(int id)
    {
        return _demployeeSkillService.DeleteEmployeeSkill(id);
    }

    [HttpGet("GetEmployeeSkillById")]
    public EmployeeSkillBase GetEmployeeSkillById(int id)
    {
        return _demployeeSkillService.GetEmployeeSkillById(id);
    }

    [HttpGet("GetEmployeeSkills")]
    public List<EmployeeSkillBase> GetEmployeeSkills()
    {
        return _demployeeSkillService.GetEmployeeSkills();
    }
}