using System;

namespace API.Dtos.RequestDto
{
    public class LessonDto
    {
        public string LessonCode { get; set; }
        public int Akts { get; set; }
        public int TheoryTime { get; set; }
        public int PracticeTime { get; set; }
        public string LessonName { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? MidTermTime { get; set; }
        public DateTime? FinalExamTime { get; set; }
        public DateTime? MakeUpExamTime { get; set; }
        public string ClassRoomCode { get; set; }
        public string ExamClassRoomCode { get; set; }
        public string TeacherId { get; set; }
        public int SemesterId { get; set; }
        public int StudyProgramId { get; set; }
    }
}
