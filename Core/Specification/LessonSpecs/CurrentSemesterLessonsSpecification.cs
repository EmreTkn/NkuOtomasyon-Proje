using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class CurrentSemesterLessonsSpecification : BaseSpecification<Lesson>
    {
        public CurrentSemesterLessonsSpecification(int semesterId) : base(src => src.Semester.Id == semesterId)
        {
            AddInclude(src => src.Teacher);
        }
    }
}
