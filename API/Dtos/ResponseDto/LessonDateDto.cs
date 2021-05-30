
using System.Runtime.Serialization;

namespace API.Dtos.ResponseDto
{
    public enum LessonDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public class LessonDateDto
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public LessonDay LessonDay { get; set; }
        public int LessonStartHour { get; set; }
        public int LessonCount { get; set; }
    }
}
