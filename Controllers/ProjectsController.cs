using Exam2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ExamContext _examContext;
        public ProjectsController(ExamContext examContext)
        {
            _examContext = examContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetListPr()
        {
            var project = _examContext.Projects.ToList();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Addnewpr(Project pr)
        {
            if(pr.ProjectStartDate > pr.ProjectEndDate)
            {
                return BadRequest("nhập sai tham số");
            }
            _examContext.AddAsync(pr);
            _examContext.SaveChanges();
            return Ok("thêm thành công ");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePr(Project pr)
        {
            if (pr.ProjectStartDate > pr.ProjectEndDate)
            {
                return BadRequest("nhập sai tham số");
            }
            _examContext.Update(pr);
            _examContext.SaveChanges();
            return Ok("Update thành công ");
        }
        [HttpDelete]
        public async Task<IActionResult> Deletepr(int id)
        {
            var pr = _examContext.Projects.FirstOrDefault(o => o.Projectid == id);
            if(pr == null)
            {
                return BadRequest("không tìm thấy bài này ");
            }
            _examContext.Projects.Remove(pr);
            return Ok("xóa thành công ");
        }
    }
}
