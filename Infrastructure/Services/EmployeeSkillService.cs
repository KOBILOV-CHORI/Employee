using Domain.Dtos.EmployeeSkill;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class EmployeeSkillService
{
    private readonly DataContext _context;

    public EmployeeSkillService(DataContext context)
    {
        _context = context;
    }

    public EmployeeSkillBase AddEmployeeSkill(EmployeeSkillBase employeeSkill)
    {
        _context.EmployeeSkills.Add(new EmployeeSkill()
        {
            EmployeeId = employeeSkill.EmployeeId,
            SkillId = employeeSkill.SkillId
        });
        _context.SaveChanges();
        return employeeSkill;
    }

    public EmployeeSkillBase UpdateEmployeeSkill(EmployeeSkillBase employeeSkill)
    {
        var find = _context.EmployeeSkills.Find(employeeSkill.EmployeeId);
        if (find != null)
        {
            find.EmployeeId = employeeSkill.EmployeeId;
            find.SkillId = employeeSkill.SkillId;
            _context.SaveChanges();
        }
        return employeeSkill;
    }

    public bool DeleteEmployeeSkill(int id)
    {
        var find = _context.EmployeeSkills.Find(id);
        if (find != null)
        {
            _context.EmployeeSkills.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public EmployeeSkillBase GetEmployeeSkillById(int id)
    {
        var find = _context.EmployeeSkills.Find(id);
        if (find == null) return new EmployeeSkillBase();
        return new EmployeeSkillBase()
        {
            EmployeeId = find.EmployeeId,
            SkillId = find.SkillId
        };
    }

    public List<EmployeeSkillBase> GetEmployeeSkills()
    {
        return _context.EmployeeSkills.Select(c => new EmployeeSkillBase()
        {
            EmployeeId = c.EmployeeId,
            SkillId = c.SkillId
        }).ToList();
    }
}