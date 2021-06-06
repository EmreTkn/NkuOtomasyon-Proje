using Core.Entities;

namespace Core.Specification.UpdateSpecs
{
    public class StudentPhotoSpecification : BaseSpecification<Photo>
    {
        public StudentPhotoSpecification(string studentId) : base(src => src.StudentId == studentId)
        {
            
        }
    }
}
