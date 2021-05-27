using System;
using Core.Entities;

namespace API.Dtos.ResponseDto
{
    public class PersonalInformationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TcNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthCity { get; set; }
        public string Nationality { get; set; }
        public bool MilitaryStatus { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
    }
}
