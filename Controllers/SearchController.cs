using Exam2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly ExamContext _examContext;
        public SearchController(ExamContext examContext)
        {
            _examContext = examContext;
        }
        [HttpGet]
        public async Task<IActionResult> SearchProject(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }
            var result = _examContext.Projects.Where(p=> p.ProjectName.ToLower().Contains (keyword.ToLower())).ToList();
            return Ok(result);
        }

    }
}
