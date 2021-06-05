using System.Collections.Generic;
using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class FailedLessonsSpecification : BaseSpecification<Grade>
    {
        public FailedLessonsSpecification(int semesterId, List<string> lessonCodes) : base(x =>
            x.Lesson.Semester.Id == semesterId && 
            !lessonCodes.Contains(x.Lesson.LessonCode) && 
            x.FailedLowGrade || 
            x.FailedAbsenteeism)
        {
            AddInclude(src => src.Lesson);
            AddInclude(src => src.Lesson.Teacher);
        }
    }
}
