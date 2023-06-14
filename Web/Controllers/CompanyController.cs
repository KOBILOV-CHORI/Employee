using Domain.Dtos.Company;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("AddCompany")]
    public CompanyBase AddCompany([FromForm]CompanyBase company)
    {
        return _companyService.AddCompany(company);
    }

    [HttpPut("UpdateCompany")]
    public CompanyBase UpdateCompany([FromForm]CompanyBase company)
    {
        return _companyService.UpdateCompany(company);
    }
    [HttpDelete("DeleteCompany")]
    public bool DeleteCompany(int id)
    {
        return _companyService.DeleteCompany(id);
    }

    [HttpGet("GetCompanyById")]
    public CompanyBase GetCompanyById(int id)
    {
        return _companyService.GetCompanyById(id);
    }

    [HttpGet("GetCompanies")]
    public List<CompanyBase> GetCompanies()
    {
        return _companyService.GetCompanies();
    }
}