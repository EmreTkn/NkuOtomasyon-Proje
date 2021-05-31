using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.ResponseDto
{
    public class SemesterGradeCardDto : GradeDto
    {
        public string TeacherName { get; set; }
        public bool? StatusAbsenteeism { get; set; }
        public LessonStatus SuccessStatus { get; set; }
        public int? GradeAverage { get; set; }
        public int? MidExam { get; set; }
        public int? FinalExam { get; set; }
        public int? LastExam { get; set; }
    }
}
