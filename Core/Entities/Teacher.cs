using System.Collections.Generic;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class Teacher
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string UserName { get; set; }
        public List<Lesson> Lessons { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public Types Type { get; set; } = Types.Teacher;
    }
}
