
namespace API.Dtos.RequestDto
{
    public class GradesUpdateDto
    {
        public string StudentNumber { get; set; }
        public string LessonCode { get; set; }
        public bool FailedAbsenteeism { get; set; }
        public bool FailedLowGrade { get; set; }
        public int? MidTerm { get; set; }
        public int? FinalExam { get; set; }
        public int? MakeUpExam { get; set; }
    }
}
