using System.Collections.Generic;
using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class FailedLessonsSpecification : BaseSpecification<Grade>
    {
        public FailedLessonsSpecification(int semesterId) : base(x =>
            x.Lesson.Semester.Id == semesterId &&
            x.FailedLowGrade || 
            x.FailedAbsenteeism)
        {
            AddInclude(src => src.Lesson);
            AddInclude(src => src.Lesson.Teacher);
            AddInclude(src => src.Student);
        }
    }
}
