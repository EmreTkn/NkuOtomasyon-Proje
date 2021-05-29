using Core.Entities;

namespace Core.Specification.StudentSpecs
{
   public class StudentGradesSpecification : BaseSpecification<Grade>
    {
        public StudentGradesSpecification(string studentId) : base(x => x.Student.Id == studentId)
        {
            AddInclude(x => x.Lesson);
            AddInclude(x => x.Lesson.Semester);
            AddInclude(x => x.Lesson.Teacher);
        }
    }
}
