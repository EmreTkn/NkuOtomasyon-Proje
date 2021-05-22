using System.Collections.Generic;

namespace Core.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public List<StudyProgram> StudyPrograms { get; set; }
    }
}
