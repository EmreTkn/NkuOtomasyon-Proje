
using Core.Entities;

namespace Core.Specification.SemesterSpecs
{
   public class StudentSemestersSpecification : BaseSpecification<Semester>
    {
        public StudentSemestersSpecification(int semesterId) : base(sem => sem.Id <= semesterId) 
        {
            AddInclude(x =>x.Lessons);
        }
    }
}
