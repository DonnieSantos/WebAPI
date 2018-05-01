using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public Dictionary<int, Student> Get(CheckBox onlyShowStudentsFailingACourse)
        {
            if (onlyShowStudentsFailingACourse.IsChecked)
            {
                var allStudents = Student.GetFromSession(HttpContext);
                var filteredStudents = new Dictionary<int, Student>();

                foreach (Student student in allStudents.Values)
                {
                    if (IsStudentFailingAnyCourse(student.ID))
                    {
                        filteredStudents.Add(student.ID, student);
                    }
                }

                return filteredStudents;
            }

            return Student.GetFromSession(HttpContext);
        }

        private bool IsStudentFailingAnyCourse(int studentID)
        {
            var courses = Course.GetFromSession(HttpContext);

            foreach (Course course in courses.Values)
            {
                if (course.Grades.ContainsKey(studentID))
                {
                    if (course.Grades[studentID] < 60)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}