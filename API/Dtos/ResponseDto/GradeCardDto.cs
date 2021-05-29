using System;
using System.Collections.Generic;
using CloudinaryDotNet;


namespace API.Dtos.ResponseDto
{
    public class GradeCardDto
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
        public int Semester { get; set; }
        public string LessonYear { get; set; }
        public int? SemesterGrade { get; set; }
       
    }

}
