using Domain.Dtos.Company;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class CompanyService
{
    private readonly DataContext _context;

    public CompanyService(DataContext context)
    {
        _context = context;
    }

    public CompanyBase AddCompany(CompanyBase company)
    {
        _context.Companies.Add(new Company()
        {
            Id = company.Id,
            Name = company.Name
        });
        _context.SaveChanges();
        return company;
    }

    public CompanyBase UpdateCompany(CompanyBase company)
    {
        var find = _context.Companies.Find(company.Id);
        if (find != null)
        {
            find.Id = company.Id;
            find.Name = company.Name;
            _context.SaveChanges();
        }
        return company;
    }

    public bool DeleteCompany(int id)
    {
        var find = _context.Companies.Find(id);
        if (find != null)
        {
            _context.Companies.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public CompanyBase GetCompanyById(int id)
    {
        var find = _context.Companies.Find(id);
        if (find == null) return new CompanyBase();
        return new CompanyBase()
        {
            Id = find.Id,
            Name = find.Name
        };
    }

    public List<CompanyBase> GetCompanies()
    {
        return _context.Companies.Select(c => new CompanyBase()
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}