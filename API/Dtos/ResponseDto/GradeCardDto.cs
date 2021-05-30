
namespace API.Dtos.ResponseDto
{
    public class GradeCardDto : GradeDto
    {
        public string TeacherName { get; set; }
        public int TheoryTime { get; set; }
        public int PracticeTime { get; set; }
        public int? GradesAverage { get; set; }
        public int Semester { get; set; }
        public string LessonYear { get; set; }
        public int? SemesterGrade { get; set; }
       
    }

}
