using Core.Entities;

namespace Core.Specification.StudentSpecs
{
   public class StudentLessonsSpecification : BaseSpecification<StudyLesson>
    {
        public StudentLessonsSpecification(string studentId, int semesterId ) : base(x => x.StudentId == studentId
            && x.Lesson.Semester.Id == semesterId)
        {
            AddInclude(x => x.Lesson);
            AddInclude(x => x.Lesson.ExamClassRoom);
        }
    }
}
