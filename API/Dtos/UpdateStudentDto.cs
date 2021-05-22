using Microsoft.AspNetCore.Http;

namespace API.Dtos
{
    public class UpdateStudentDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TcNumber { get; set; }
        public string SchoolNumber { get; set; }
        public int StudyProgramId { get; set; }
        public int FacultyId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
