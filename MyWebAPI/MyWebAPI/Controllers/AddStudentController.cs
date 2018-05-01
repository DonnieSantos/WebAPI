using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    public class AddStudentController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var students = Student.GetFromSession(HttpContext);
            students.Add(student.ID, student);
            Student.SetToSession(HttpContext, students);
        }
    }
}