using System;
using Core.Entities;

namespace API.Dtos
{
    public class UpdateStudentDto
    {
        public string StudentNumber { get; set; }
        public EducationType EducationType { get; set; }
        public int StudyTimeId { get; set; }
        public string AdvisorTeacherId { get; set; }
        public double GradeAverage { get; set; }
        public int FacultyId { get; set; }
        public int StudyProgramId { get; set; }
        public int SemesterId { get; set; }
        public RecordType RecordType { get; set; }
        public string ComeFromUniversity { get; set; }
        public string ComeFromFaculty { get; set; }
        public string ComeFromBranch { get; set; }
        public DateTime GraduationYear { get; set; }
    }
}
