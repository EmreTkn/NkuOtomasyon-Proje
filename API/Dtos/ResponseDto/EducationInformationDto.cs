using System;

namespace API.Dtos.ResponseDto
{
    public class EducationInformationDto
    {
        public string SchoolNumber { get; set; }
        public string EducationType { get; set; }
        public string StudyTime { get; set; }
        public string AdvisorTeacher { get; set; }
        public double GradeAverage { get; set; }
        public string Faculty { get; set; }
        public string StudyProgram { get; set; }
        public string CurrentClass { get; set; }
        public string Semester { get; set; }
        public string EducationYear { get; set; }
        public DateTime RegisterTime { get; set; }

        //kayıt öncesi bilgileri
        public string RecordType { get; set; }
        public string ComeFromUniversity { get; set; }
        public string ComeFromFaculty { get; set; }
        public string ComeFromBranch { get; set; }
        public DateTime GraduationYear { get; set; }
    }
}
