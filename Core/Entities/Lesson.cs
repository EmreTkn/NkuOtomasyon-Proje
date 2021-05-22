using System;
using System.Collections.Generic;

namespace Core.Entities
{
   public class Lesson
    {
        public string LessonCode { get; set; }
        public int Akts { get; set; }
        public int TheoryTime { get; set; }
        public int PracticeTime { get; set; }
        public string LessonName { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime MidTermTime { get; set; }
        public DateTime FinalExamTime { get; set; }
        public DateTime MakeUpExamTime { get; set; }
        public Classroom LessonClassRoom { get; set; }
        public Classroom ExamClassRoom { get; set; }
        public DateTime StudyTime { get; set; }
        public string LessonDay { get; set; } //this and 3 lines below it needs to set a new table
        public int LessonStartHour { get; set; }
        public int LessonofNumber { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudyLesson> StudyLessons { get; set; }
        public Semester Semester { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public List<PdfFile> PdfFiles { get; set; }
    }
}
