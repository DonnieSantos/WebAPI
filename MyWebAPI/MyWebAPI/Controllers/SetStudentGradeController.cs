using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SetStudentGradeController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Grade data)
        {
            var courses = Course.GetFromSession(HttpContext);
            var students = Student.GetFromSession(HttpContext);
            courses[data.CourseID].SetStudentGrade(data.StudentID, data.Score);
            Course.SetToSession(HttpContext, courses);
        }
    }
}