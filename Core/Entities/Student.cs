using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class Student:IdentityUser
    {
        public Student()
        {
            RegistrationTime = DateTime.Today;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int TcNumber { get; set; }
        public string SchoolNumber { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public List<StudyLesson> StudyLessons { get; set; }
        public Faculty Faculty { get; set; }
        public DateTime RegistrationTime { get; set; }
        public Semester Semester { get; set; }
        public List<Grade> Grades { get; set; }
        public Photo Photo { get; set; }

    }
}
