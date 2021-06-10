using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specification.TeacherSpecs
{
    public class StudentsByLessonSpecification : BaseSpecification<StudyLesson>
    {
        public StudentsByLessonSpecification(string lessonCode) : base(src => src.LessonCode == lessonCode)
        {
            AddInclude(src => src.Student);
        }
    }
}
