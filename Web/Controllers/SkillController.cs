using Domain.Dtos.Skill;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillController : ControllerBase
{
    private readonly SkillService _skillService;

    public SkillController(SkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpPost("AddSkill")]
    public SkillBase AddSkill([FromForm]SkillBase skill)
    {
        return _skillService.AddSkill(skill);
    }

    [HttpPut("UpdateSkill")]
    public SkillBase UpdateSkill([FromForm]SkillBase skill)
    {
        return _skillService.UpdateSkill(skill);
    }
    [HttpDelete("DeleteSkill")]
    public bool DeleteSkill(int id)
    {
        return _skillService.DeleteSkill(id);
    }

    [HttpGet("GetSkillById")]
    public SkillBase GetSkillById(int id)
    {
        return _skillService.GetSkillById(id);
    }

    [HttpGet("GetSkills")]
    public List<SkillBase> GetSkills()
    {
        return _skillService.GetSkills();
    }
}