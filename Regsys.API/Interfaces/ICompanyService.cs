using Regsys.API.Models;

namespace Regsys.API.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Company GetCompany(int id);
        void AddCompany(Company company);
        void UpdateCompany(int id, Company company);
        void DeleteCompany(int id);
    }
}
