using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        public string MinimumGrade
        {
            get { return HttpContext.Request.Query["minimumGrade"]; }
        }

        [HttpGet]
        public IList<Student> Get()
        {
            if (string.IsNullOrEmpty(MinimumGrade)) return HttpContext.Session.GetStudents();
            int minimumGrade = int.Parse(HttpContext.Request.Query["minimumGrade"].ToString());
            return HttpContext.Session.GetStudents().Where(student => { return student.Grade >= minimumGrade; }).ToList();
        }

        [HttpGet("{index}", Name = "Get")]
        public Student Get(int index)
        {
            return HttpContext.Session.GetStudents()[index];
        }

        [HttpPost]
        public void Post([FromBody]IList<Student> students)
        {
            HttpContext.Session.ClearStudents();
        }
    }
}