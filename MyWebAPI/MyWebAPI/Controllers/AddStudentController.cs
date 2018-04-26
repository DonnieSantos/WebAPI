using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AddStudentController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var students = HttpContext.Session.GetStudents();
            students.Add(student);
            HttpContext.Session.Set(SessionKey.Students, students);
        }
    }
}