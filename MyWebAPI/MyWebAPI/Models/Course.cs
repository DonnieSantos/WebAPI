using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MyWebAPI
{
    [Serializable]
    public class Course
    {
        #region Session
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public const string sessionKey = "course";

        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Dictionary<int, int> Grades { get; set; }

        public static Dictionary<int, Course> GetFromSession(HttpContext context)
        {
            var courseData = context.Session.GetString(sessionKey);
            if (courseData == null) return new Dictionary<int, Course>();
            var courses = JsonConvert.DeserializeObject<Dictionary<int, Course>>(courseData);
            return courses;
        }

        public static void SetToSession(HttpContext context, Dictionary<int, Course> courses)
        {
            context.Session.SetString(sessionKey, JsonConvert.SerializeObject(courses));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        public Course(string name, int id)
        {
            ID = id;
            Name = name;
            Students = new List<Student>();
            Grades = new Dictionary<int, int>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            Grades.Add(student.ID, 0);
        }

        public void SetStudentGrade(int studentID, int grade)
        {
            Grades[studentID] = grade;
        }

        public void RemoveStudent(int id)
        {
            try
            {
                var studentToRemove = GetStudent(id);

                if (studentToRemove != null)
                {
                    Grades.Remove(studentToRemove.ID);
                    Students.Remove(studentToRemove);
                }
            }
            catch { }
        }

        public Student GetStudent(int id)
        {
            try
            {
                return Students.Where(student => { return student.ID == id; }).ToList()[0];
            }
            catch
            {
                return null;
            }
        }
    }
}