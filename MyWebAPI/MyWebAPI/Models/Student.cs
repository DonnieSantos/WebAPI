using System;

namespace MyWebAPI
{
    [Serializable]
    public class Student
    {
        public int ID { get; set; }
        public int Grade { get; set; }
        public string Name { get; set; }
    }
}