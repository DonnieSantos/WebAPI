using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyWebAPI.Controllers
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static List<Student> GetStudents(this ISession session)
        {
            var students = session.Get<List<Student>>(SessionKey.Students);

            if (students == null)
            {
                session.ClearStudents();
            }

            return session.Get<List<Student>>(SessionKey.Students);
        }

        public static void ClearStudents(this ISession session)
        {
            session.Set<IList<Student>>(SessionKey.Students, new List<Student>());
        }
    }
}