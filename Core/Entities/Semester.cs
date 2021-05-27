using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum CurrentYear
    {
        [EnumMember(Value = "1. Sınıf")]
        FirstClass,
        [EnumMember(Value = "2. Sınıf")]
        SecondClass,
        [EnumMember(Value = "3. Sınıf")]
        ThirdClass,
        [EnumMember(Value = "4. Sınıf")]
        FourthClass
    }
   public class Semester
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public CurrentYear Year { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
    }
}
