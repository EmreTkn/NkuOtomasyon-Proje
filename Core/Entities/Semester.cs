using System.Collections.Generic;
using Core.Entities.Identity;

namespace Core.Entities
{
   public class Semester
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
    }
}
