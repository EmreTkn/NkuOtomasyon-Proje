
namespace Core.Entities
{
   public class StudentAffairs
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public Faculty Faculty { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }
}
