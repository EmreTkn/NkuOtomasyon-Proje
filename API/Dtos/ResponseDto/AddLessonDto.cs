using System.Collections.Generic;

namespace API.Dtos.ResponseDto
{
    public class AddLessonDto
    {
        public List<StudyProgramDto> Programs { get; set; }
        public List<SemesterDto> Semesters { get; set; }
        public List<ClassRoomDto> ClassRooms { get; set; }
        public List<TeacherDto> Teachers { get; set; }
    }
}
