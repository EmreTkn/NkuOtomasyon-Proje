using Core.Entities.Identity;

namespace Core.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification()
        {
            
        }

        public UserSpecification(string schoolNumber):base(u=>u.UserName==schoolNumber)
        {
                
        }
    }
}
