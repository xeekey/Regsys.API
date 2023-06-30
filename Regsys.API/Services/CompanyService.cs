namespace Regsys.API.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Regsys.API.Models;

    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompany(int id)
        {
            return _context.Companies.Find(id);
        }

        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void UpdateCompany(int id, Company company)
        {
            var existingCompany = _context.Companies.Find(id);
            if (existingCompany == null)
                return;

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            existingCompany.ContactInformation = company.ContactInformation;
            _context.SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
                return;

            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
    }

}
