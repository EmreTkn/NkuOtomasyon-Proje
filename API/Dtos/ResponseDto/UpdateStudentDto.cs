
using System.Collections.Generic;

namespace API.Dtos.ResponseDto
{
    public class UpdateStudentDto
    {
        public List<TeacherBasicDto> Teachers { get; set; }
        public List<FacultiesDto> Faculties { get; set; }
        public List<StudyProgramDto> StudyPrograms { get; set; }
    }
}
