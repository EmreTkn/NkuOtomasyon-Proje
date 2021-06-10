
using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos.RequestDto
{
    public class LessonAddDto
    {
        public string LessonCode { get; set; }
        public int Akts { get; set; }
        public int TheoryTime { get; set; }
        public int PracticeTime { get; set; }
        public string LessonName { get; set; }
        public bool LessonType { get; set; }
        public DateTime MidTermTime { get; set; }
        public DateTime FinalExamTime { get; set; }
        public DateTime MakeUpExamTime { get; set; }
        public int LessonClassRoomId { get; set; }
        public DateTime StudyTime { get; set; }
        public string LessonDay { get; set; }
        public int LessonStartHour { get; set; }
        public int LessonofNumber { get; set; }
        public int SemesterId { get; set; }
        public int StudyProgramId { get; set; }
    }
}
