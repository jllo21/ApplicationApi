using ApplicationApi.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApplicationApi.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationsController(IApplicationRepository applicationRepository) => _applicationRepository = applicationRepository;

        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            // GET Request - Grab all Applications
            var applications = await _applicationRepository.GetApplications();
            return Ok(applications);
        }

        [HttpGet("{id}", Name = "ApplicationById")]
        public async Task<IActionResult> GetApplication(int id)
        {
            // GET Request - Grab Application by Id
            var application = await _applicationRepository.GetApplication(id);
            if (application is null)
            {
                return NotFound();
            }
            return Ok(application);
        }
        [HttpGet("category", Name ="ApplicationByCategoryDateRange")]
        public async Task<IActionResult> GetApplications(string categoryName, DateTime startDate, DateTime endDate)
        {
            // GET Request - Grab Application by CategoryName within Date Range
            var applications = await _applicationRepository.GetCategoryDateApplications(categoryName, startDate, endDate);
            if(applications is null)
            {
                return NotFound();
            }
            return Ok(applications);
        }
    }
}
