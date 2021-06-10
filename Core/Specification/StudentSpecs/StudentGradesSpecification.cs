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

        public StudentGradesSpecification(string studentId, int semesterId) 
            : base(src => src.SemesterId == semesterId && src.Student.Id == studentId)
        {
            AddInclude(src => src.Lesson);
            AddInclude(src => src.Lesson.Teacher);
        }
    }
}
