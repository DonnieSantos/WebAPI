using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RemoveStudentFromCourseController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Registry data)
        {
            var courses = Course.GetFromSession(HttpContext);
            var students = Student.GetFromSession(HttpContext);
            courses[data.CourseID].RemoveStudent(data.StudentID);
            Course.SetToSession(HttpContext, courses);
        }
    }
}