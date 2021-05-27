using System;
using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum EducationType
    {
        [EnumMember(Value = "Önlisans")]
        AssociateDegree,
        [EnumMember(Value = "Lisans")]
        Degree,
        [EnumMember(Value = "Yüksek Lisans")]
        MasterDegree,
    }

    public enum RecordType
    {
        DGS,
        LYS,
        YatayGecis
    }
   public class StudentInformation
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public EducationType EducationType { get; set; }
        public StudyTime StudyTime { get; set; }
        public Teacher AdvisorTeacher { get; set; }
        public double GradeAverage { get; set; }
        public Faculty Faculty { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public Semester Semester { get; set; }
        public RecordType RecordType { get; set; }
        public string ComeFromUniversity { get; set; }
        public string ComeFromFaculty { get; set; }
        public string ComeFromBranch { get; set; }
        public DateTime GraduationYear { get; set; }

    }
}
