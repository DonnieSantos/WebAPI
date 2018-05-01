using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AddStudentToCourseController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Registry data)
        {
            var courses = Course.GetFromSession(HttpContext);
            var students = Student.GetFromSession(HttpContext);
            courses[data.CourseID].AddStudent(students[data.StudentID]);
            Course.SetToSession(HttpContext, courses);
        }
    }
}