
namespace Core.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public string ClassRoomCode { get; set; }
        public string ClassRoomName { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }

}
