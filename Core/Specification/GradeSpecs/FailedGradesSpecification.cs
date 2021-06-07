using System.Collections.Generic;
using Core.Entities;

namespace Core.Specification.GradeSpecs
{
    public class FailedGradesSpecification : BaseSpecification<Grade>
    {
        public FailedGradesSpecification(List<string> lessonCodes, int semesterId) : 
            base(src => 
                lessonCodes.Contains(src.Lesson.LessonCode) 
                &&src.SemesterId == semesterId
               /* && src.SemesterId == semesterId - 2*/)
        {
            AddInclude(src => src.Lesson);
        }
    }
}
