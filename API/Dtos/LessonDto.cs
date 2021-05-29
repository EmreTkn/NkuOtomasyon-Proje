
namespace API.Dtos
{
    public class LessonDto
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public int Akts { get; set; }
        public int TheoryTime { get; set; }
        public int PracticeTime { get; set; }
        public int? GradesAverage { get; set; }
        public string Letter { get; set; }
        public double? LetterGrade { get; set; }
        public int? SemesterGrade { get; set; }
    }
}
