using ApplicationApi.Context;
using ApplicationApi.Contracts;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        
        private readonly DapperContext _context;

        public ApplicationRepository(DapperContext context) => _context = context;

        // Load Data into Application Model and return
        public async Task<IEnumerable<Application>> GetApplications()
        {
            var query = "SELECT * FROM Application";

            using(var connection = _context.CreateConnection())
            {
                var applications = await connection.QueryAsync<Application>(query);
                // Convert to list due to IEnumerable
                return applications.ToList();
            }
        }

        public async Task<Application> GetApplication(int id)
        {
            var query = "SELECT * FROM Application WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                var application = await connection.QuerySingleOrDefaultAsync<Application>(query, new { id });
                return application;
            }
        }

        public async Task<IEnumerable<Application>> GetCategoryDateApplications(string categoryName, DateTime startDate, DateTime endDate)
        {
            // Apparently theres a issue comparing DateTimes to dates in the db (DateTimeUpdated BETWEEN @startDate AND @endDate would not work here)
            // Specifiying collate nocase (case insensitive) in the column definition for BusinessCategory would greatly increase this queries speed and allow COLLATE NOCASE to be removed from the query
            var query = "SELECT * FROM Application WHERE BusinessCategory = @categoryName COLLATE NOCASE AND DateTimeUpdated >= @startDate AND DateTimeUpdated < date(@endDate,'+1 day')";
            using(var connection = _context.CreateConnection())
            {
                var applications = await connection.QueryAsync<Application>(query, new { categoryName, startDate, endDate });
                return applications.ToList();
            }
        }
    }
}
