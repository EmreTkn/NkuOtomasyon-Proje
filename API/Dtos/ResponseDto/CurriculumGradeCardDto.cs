
namespace API.Dtos.ResponseDto
{
    public enum LessonStatus
    {
        Success,
        Pending,
        Failed,
        Unregistered

    }
    public class CurriculumGradeCardDto : GradeDto
    {
        public bool LessonType { get; set; }
        public LessonStatus LessonStatus { get; set; } = LessonStatus.Unregistered;
        public int NumberOfLessonTaken { get; set; } = 0;
        public int? GradesAverage { get; set; }
        public bool? StatusAbsenteeism { get; set; }
        public LessonStatus SuccessStatus { get; set; }
    }
}
