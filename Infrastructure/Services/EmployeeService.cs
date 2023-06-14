using Domain.Dtos.Employee;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public EmployeeBase AddEmployee(EmployeeBase employee)
    {
        _context.Employees.Add(new Employee()
        {
            Id = employee.Id,
            Name = employee.Name,
            CompanyId = employee.CompanyId
        });
        _context.SaveChanges();
        return employee;
    }

    public EmployeeBase UpdateEmployee(EmployeeBase employee)
    {
        var find = _context.Employees.Find(employee.Id);
        if (find != null)
        {
            find.Id = employee.Id;
            find.Name = employee.Name;
            _context.SaveChanges();
        }
        return employee;
    }

    public bool DeleteEmployee(int id)
    {
        var find = _context.Employees.Find(id);
        if (find != null)
        {
            _context.Employees.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public EmployeeBase GetEmployeeById(int id)
    {
        var find = _context.Employees.Find(id);
        if (find == null) return new EmployeeBase();
        return new EmployeeBase()
        {
            Id = find.Id,
            Name = find.Name
        };
    }

    public List<EmployeeBase> GetEmployees()
    {
        return _context.Employees.Select(c => new EmployeeBase()
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}