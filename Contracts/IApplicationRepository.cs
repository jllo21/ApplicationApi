using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Contracts
{
    public interface IApplicationRepository
    {
        public Task<IEnumerable<Application>> GetApplications();
        public Task<Application> GetApplication(int id);
        public Task<IEnumerable<Application>> GetCategoryDateApplications(string categoryName, DateTime startDate, DateTime endDate);
    }
}
