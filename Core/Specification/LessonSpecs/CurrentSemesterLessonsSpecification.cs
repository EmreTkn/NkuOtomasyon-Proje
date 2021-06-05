using System.Collections.Generic;
using Core.Entities;

namespace Core.Specification.LessonSpecs
{
    public class CurrentSemesterLessonsSpecification : BaseSpecification<Lesson>
    {
        public CurrentSemesterLessonsSpecification(int semesterId, List<string> lessonCodes) : base(src => src.Semester.Id == semesterId && !lessonCodes.Contains(src.LessonCode))
        {
            AddInclude(src => src.Teacher);
        }
    }
}
