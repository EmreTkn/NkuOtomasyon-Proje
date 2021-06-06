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
           AddInclude(x => x.Information);
           AddInclude(x => x.Information.Semester);
        }
    }
}
