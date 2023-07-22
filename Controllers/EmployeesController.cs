using Exam2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ExamContext _examContext;
        public EmployeesController(ExamContext examContext)
        {
            _examContext = examContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetListEmploy()
        {
            var project = _examContext.Employees.ToList();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Addnewpr(Employee em)
        {
            //if ((em.EmployeeDob-DateTime.Now)<)
            //{
            //    return BadRequest("nhập sai tham số");
            //}
            _examContext.Employees.AddAsync(em);
            _examContext.SaveChanges();
            return Ok("thêm thành công ");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePr(Employee pr)
        {
            _examContext.Employees.Update(pr);
            _examContext.SaveChanges();
            return Ok("Update thành công ");
        }
        [HttpDelete]
        public async Task<IActionResult> Deletepr(int id)
        {
            var pr = _examContext.Employees.FirstOrDefault(o => o.EmployeeId == id);
            if (pr == null)
            {
                return BadRequest("không tìm người này ");
            }
            _examContext.Projects.Remove(pr);
            return Ok("xóa thành công ");
        }
        [Route("GetDetail")]
        [HttpGet]
        public async Task<IActionResult> GetDetail(int id)
        {
            var employ = _examContext.Employees.FirstOrDefault(o => o.EmployeeId == id);
        }
    }
}
