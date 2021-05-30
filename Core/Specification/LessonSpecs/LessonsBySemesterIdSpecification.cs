using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class LessonsBySemesterIdSpecification :BaseSpecification<Lesson>
    {
        public LessonsBySemesterIdSpecification(int semesterId) : base(les => les.Semester.Id <= semesterId)
        {
            
        }
    }
}
