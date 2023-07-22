using Exam2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ExamContext _ContextPr;
        public ProjectsController(ExamContext examContext)
        {
            _ContextPr = examContext;
        }
        [Route("GetProject")]
        [HttpGet]
        public async Task<IActionResult> GetListPr()
        {
            var project = _ContextPr.Projects.ToList();
            return Ok(project);
        }


        [Route("AddNewpr")]
        [HttpPost]
        public async Task<IActionResult> Addnewpr(Project pr)
        {
            if(pr.ProjectStartDate > pr.ProjectEndDate)
            {
                return BadRequest("nhập sai tham số");
            }
            _ContextPr.AddAsync(pr);
            _ContextPr.SaveChanges();
            return Ok("thêm thành công ");
        }

        [Route("UpdatePr")]
        [HttpPut]
        public async Task<IActionResult> UpdatePr(Project pr)
        {
            if (pr.ProjectStartDate > pr.ProjectEndDate)
            {
                return BadRequest("nhập sai tham số");
            }
            _ContextPr.Update(pr);
            _ContextPr.SaveChanges();
            return Ok("Update thành công ");
        }
        [Route("DeletePr")]
        [HttpDelete]
        public async Task<IActionResult> Deletepr(int id)
        {
            var pr = _ContextPr.Projects.FirstOrDefault(o => o.Projectid == id);
            if(pr == null)
            {
                return BadRequest("không tìm thấy bài này ");
            }
            _ContextPr.Projects.Remove(pr);
            return Ok("xóa thành công ");
        }
    }
}
