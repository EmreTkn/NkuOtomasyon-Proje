using System;

namespace API.Dtos.ResponseDto
{
    public class FinalExamDto : ExamDateDto
    {
        public DateTime FinalExamDate { get; set; }
        public string ClassroomName { get; set; }
    }
}
