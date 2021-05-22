using System.Collections.Generic;

namespace Core.Entities
{
   public class StudyProgram
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
        public Faculty Faculty { get; set; }
        public StudyTime StudyTime { get; set; }
        public List<Classroom> Classrooms { get; set; }
    }
}
