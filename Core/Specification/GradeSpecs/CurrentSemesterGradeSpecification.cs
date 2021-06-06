using System.Xml.Serialization;
using Core.Entities;

namespace Core.Specification.GradeSpecs
{
   public class CurrentSemesterGradeSpecification : BaseSpecification<Grade>
    {
        public CurrentSemesterGradeSpecification(int semesterId) : base(x => x.SemesterId == semesterId)
        {
            AddInclude(x => x.Lesson.Teacher);
        }

        public CurrentSemesterGradeSpecification(int semesterId, string studentId) : 
            base(src => src.SemesterId == semesterId && src.Student.Id == studentId)
        {
            AddInclude(src => src.Lesson);
        }

        public CurrentSemesterGradeSpecification(int semesterId, string studentId, string lessonCode) : 
            base(src => src.SemesterId ==semesterId &&
                        src.Student.Id == studentId &&
                        src.Lesson.LessonCode == lessonCode)
        {
            
        }

    }
}
