using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Types Type { get; set; }
    }
}
