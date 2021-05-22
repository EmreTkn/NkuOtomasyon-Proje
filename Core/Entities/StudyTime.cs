using System.Collections.Generic;

namespace Core.Entities
{
    public class StudyTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudyProgram> StudyPrograms { get; set; }
    }
}
