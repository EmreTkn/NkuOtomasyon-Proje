using Core.Entities;

namespace Core.Specification.StudentSpecs
{
    public class StudentEducationInformationSpecification : BaseSpecification<StudentInformation>
    {
        public StudentEducationInformationSpecification(string studentId) : base(s => s.StudentId == studentId)
        {
            AddInclude(s => s.Semester);
            AddInclude(s => s.StudyProgram);
            AddInclude(s => s.StudyTime);
            AddInclude(s => s.AdvisorTeacher);
            AddInclude(s => s.Faculty);
            AddInclude(s => s.Student);
        }
    }
}
