using Exam2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly ExamContext _examContextsearch;
        public SearchController(ExamContext examContext)
        {
            _examContextsearch = examContext;
        }
        [Route("SearchProject")]
        [HttpGet]
        public async Task<IActionResult> SearchProject(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }
            var result = _examContextsearch.Projects.Where(p=> p.ProjectName.ToLower().Contains (keyword.ToLower())).ToList();
            return Ok(result);
        }

        [Route("SearchPrFinish")]
        [HttpGet]
        public async Task<IActionResult> ProjectFnish()
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }
            var result = _examContextsearch.Projects.Where(item=> item.ProjectEndDate<= DateTime.Now);
            return Ok(result);
        }

        [Route("SearchEmploy")]
        [HttpGet]
        public async Task<IActionResult> SearchEmploy(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }
            var result = _examContextsearch.Employees.Where(p => p.EmployeeName.ToLower().Contains(keyword.ToLower())).ToList();
            return Ok(result);
        }

    }
}
