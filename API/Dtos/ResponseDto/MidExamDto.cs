using System;

namespace API.Dtos.ResponseDto
{
    public class MidExamDto : ExamDateDto
    {
        public DateTime MidExamDate { get; set; }
        public string ClassroomName { get; set; }
    }
}
