using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class SyllabusSpecification : BaseSpecification<StudyLesson>
    {
        public SyllabusSpecification(string studentId, int semesterId) : base(x => x.StudentId == studentId 
            && x.Lesson.Semester.Id == semesterId)
        {
            AddInclude(x => x.Lesson);
        }
    }
}
