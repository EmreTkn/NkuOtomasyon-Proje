using System;

namespace API.Dtos.RequestDto
{
    public class ExamDateDto
    {
        public string LessonCode { get; set; }
        public int? ExamClassId { get; set; }
        public DateTime? MidExamDate { get; set; }
        public DateTime? FinalExamDate { get; set; }
        public DateTime? LastExamDate { get; set; }
    }
}
