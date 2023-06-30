using Microsoft.AspNetCore.Mvc;
using Regsys.API.Interfaces;
using Regsys.API.Models;
using Regsys.API.Services;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    // Get all companies
    [HttpGet]
    public IActionResult Get()
    {
        var companies = _companyService.GetAllCompanies();
        return Ok(companies);
    }

    // Get a specific company
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var company = _companyService.GetCompany(id);
        if (company == null)
            return NotFound();

        return Ok(company);
    }

    // Create a new company
    [HttpPost]
    public IActionResult Post(Company company)
    {
        _companyService.AddCompany(company);
        return CreatedAtAction(nameof(Get), new { id = company.CompanyId }, company);
    }

    // Update an existing company
    [HttpPut("{id}")]
    public IActionResult Put(int id, Company company)
    {
        if (id != company.CompanyId)
        {
            return BadRequest();
        }

        _companyService.UpdateCompany(id, company);
        return NoContent();
    }

    // Delete a company
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _companyService.DeleteCompany(id);
        return NoContent();
    }
}

