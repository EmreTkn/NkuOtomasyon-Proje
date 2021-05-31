using Core.Entities;

namespace Core.Specification.GradeSpecs
{
   public class CurrentSemesterGradeSpecification : BaseSpecification<Grade>
    {
        public CurrentSemesterGradeSpecification(int semesterId) : base(x => x.Lesson.Semester.Id == semesterId)
        {
            AddInclude(x => x.Lesson.Teacher);
        }
    }
}
