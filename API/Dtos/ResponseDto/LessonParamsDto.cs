using System.Collections.Generic;

namespace API.Dtos.ResponseDto
{
    public class LessonParamsDto
    {
        public List<SemesterDto> Semesters { get; set; }
        public List<ClassRoomDto> ClassRooms { get; set; }
        public List<StudyProgramDto> StudyPrograms { get; set; }
    }
}
