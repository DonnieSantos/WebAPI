using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebAPI
{
    [Route("api/Courses")]
    [Produces("application/json")]
    public class CoursesController : Controller
    {
        [HttpGet]
        public Dictionary<int, Course> Get()
        {
            return Course.GetFromSession(HttpContext);
        }

        [HttpPost]
        public void Post()
        {
            HttpContext.Session.Clear();
        }
    }
}