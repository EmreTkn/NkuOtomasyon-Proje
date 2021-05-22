using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specification
{
    public class StudentWithIncludesSpecification :BaseSpecification<Student>
    {
        public StudentWithIncludesSpecification()
        {

        }
        public StudentWithIncludesSpecification(string schoolNumber) : base(u => u.SchoolNumber == schoolNumber)
        {
           
        }
    }
}
