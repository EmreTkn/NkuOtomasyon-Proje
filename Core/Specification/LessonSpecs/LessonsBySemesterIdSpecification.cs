using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class LessonsBySemesterIdSpecification :BaseSpecification<Lesson>
    {
        public LessonsBySemesterIdSpecification(int semesterId) : base(les => les.Semester.Id <= semesterId)
        {
            
        }

        public LessonsBySemesterIdSpecification()
        {
            AddInclude(src => src.Teacher);
            AddOrderBy(src => src.Semester.Id);
        }
    }
}
