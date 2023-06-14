using Domain.Dtos.Skill;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class SkillService
{
    private readonly DataContext _context;

    public SkillService(DataContext context)
    {
        _context = context;
    }

    public SkillBase AddSkill(SkillBase skill)
    {
        _context.Skills.Add(new Skill()
        {
            Id = skill.Id,
            SkillName = skill.SkillName
        });
        _context.SaveChanges();
        return skill;
    }

    public SkillBase UpdateSkill(SkillBase skill)
    {
        var find = _context.Skills.Find(skill.Id);
        if (find != null)
        {
            find.Id = skill.Id;
            find.SkillName = skill.SkillName;
            _context.SaveChanges();
        }
        return skill;
    }

    public bool DeleteSkill(int id)
    {
        var find = _context.Skills.Find(id);
        if (find != null)
        {
            _context.Skills.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public SkillBase GetSkillById(int id)
    {
        var find = _context.Skills.Find(id);
        if (find == null) return new SkillBase();
        return new SkillBase()
        {
            Id = find.Id,
            SkillName = find.SkillName
        };
    }

    public List<SkillBase> GetSkills()
    {
        return _context.Skills.Select(c => new SkillBase()
        {
            Id = c.Id,
            SkillName = c.SkillName
        }).ToList();
    }
}