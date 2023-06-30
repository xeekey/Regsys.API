using Regsys.API.Models;

namespace Regsys.API.Interfaces
{
    public interface ITimeRegistrationService
    {
        IEnumerable<TimeRegistration> GetAllRegistrations();
        TimeRegistration GetRegistration(int id);
        void AddRegistration(TimeRegistration registration);
        void UpdateRegistration(int id, TimeRegistration registration);
        void DeleteRegistration(int id);
    }

}
