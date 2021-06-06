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

        public StudentLessonsSpecification(string studentId, string lessonCode) : 
            base(src => src.LessonCode ==lessonCode && src.StudentId == studentId)
        {
            
        }
    }
}
