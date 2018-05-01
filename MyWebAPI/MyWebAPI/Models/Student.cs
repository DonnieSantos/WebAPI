using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyWebAPI
{
    [Serializable]
    public class Student
    {
        #region Session
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public const string sessionKey = "students";

        public static Dictionary<int, Student> GetFromSession(HttpContext context)
        {
            var studentData = context.Session.GetString(sessionKey);
            if (studentData == null) return new Dictionary<int, Student>();
            var students = JsonConvert.DeserializeObject<Dictionary<int, Student>>(studentData);
            return students;
        }

        public static void SetToSession(HttpContext context, Dictionary<int, Student> students)
        {
            context.Session.SetString(sessionKey, JsonConvert.SerializeObject(students));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
    }
}