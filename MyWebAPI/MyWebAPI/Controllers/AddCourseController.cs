using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AddCourseController : Controller
    {
        [HttpPost]
        public void Post([FromBody]Course course)
        {
            var courses = Course.GetFromSession(HttpContext);
            courses.Add(course.ID, course);
            Course.SetToSession(HttpContext, courses);
        }
    }
}