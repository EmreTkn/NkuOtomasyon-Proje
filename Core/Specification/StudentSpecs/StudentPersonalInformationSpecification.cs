using Core.Entities;

namespace Core.Specification.StudentSpecs
{
    public class StudentPersonalInformationSpecification : BaseSpecification<StudentPersonalityInformation>
    {
        public StudentPersonalInformationSpecification(string studentId) : base(s => s.StudentId == studentId)
        {
            AddInclude(x => x.Student);
        }

    }
}
