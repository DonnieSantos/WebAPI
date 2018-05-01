namespace MyWebAPI
{
    public class Grade
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        private int _score;

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value >= 100) _score = 100;
                else if (value <= 0) _score = 0;
                else _score = value;
            }
        }
    }
}