using System.Collections.Generic;
using Core.Entities;

namespace Core.Specification.GradeSpecs
{
    public class FailedGradesSpecification : BaseSpecification<Grade>
    {
        public FailedGradesSpecification(List<string> lessonCodes, int semesterId) : 
            base(src => 
                !lessonCodes.Contains(src.Lesson.LessonCode) 
                && src.SemesterId == semesterId)
        {
            AddInclude(src => src.Lesson);
        }
    }
}
