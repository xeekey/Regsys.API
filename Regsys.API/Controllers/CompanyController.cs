using Microsoft.AspNetCore.Mvc;
using Regsys.API.Models;
using Regsys.API.Services;
using Regsys.API.Services;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var companies = _companyService.GetAllCompanies();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var company = _companyService.GetCompany(id);
        if (company == null)
            return NotFound();

        return Ok(company);
    }

    [HttpPost]
    public IActionResult Create(Company company)
    {
        _companyService.AddCompany(company);
        return Ok(company);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Company company)
    {
        _companyService.UpdateCompany(id, company);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _companyService.DeleteCompany(id);
        return NoContent();
    }
}
