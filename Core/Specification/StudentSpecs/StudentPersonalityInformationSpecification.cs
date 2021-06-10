using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Core.Entities;

namespace Core.Specification.StudentSpecs
{
    public class StudentPersonalityInformationSpecification : BaseSpecification<StudentPersonalityInformation>
    {
        public StudentPersonalityInformationSpecification(string schoolNumber) : base(src => src.Student.SchoolNumber == schoolNumber)
        {
            AddInclude(src => src.Student);
        }
    }
}
