using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specification.StudentSpecs
{
   public class StudentLessonsSpecification : BaseSpecification<StudyLesson>
    {
        public StudentLessonsSpecification(string studentId) : base(x => x.StudentId == studentId)
        {
            
        }
    }
}
