using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specification.StudentSpecs
{
    public class StudentInformationSpecification : BaseSpecification<StudentInformation>
    {
        public StudentInformationSpecification(string schoolNumber) : base(src => src.Student.SchoolNumber == schoolNumber)
        {
            AddInclude(src => src.Student);
            AddInclude(src => src.AdvisorTeacher);
            AddInclude(src => src.Faculty);
            AddInclude(src => src.StudyTime);
            AddInclude(src => src.StudyProgram);
            AddInclude(src => src.Semester);
        }
    }
}
