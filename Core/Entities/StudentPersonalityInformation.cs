

using System;

namespace Core.Entities
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum MaritalStatus
    {
        Married,
        Single
    }
   public class StudentPersonalityInformation
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public int TcNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthCity { get; set; }
        public string Nationality { get; set; }
        public bool MilitaryStatus { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.Single;
    }
}
