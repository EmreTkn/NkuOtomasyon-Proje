using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentInformation> GetStudentInformation(ClaimsPrincipal user);
    }
}
