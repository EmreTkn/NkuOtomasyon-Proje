using API.Dtos;
using API.Dtos.RequestDto;
using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.Extensions.ObjectPool;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, Student>()
                .ForMember(dst => dst.SchoolNumber, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, StudentAffairs>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));
           
            CreateMap<User, Teacher>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Classroom, ClassRoomDto>()
                .ForMember(dst => dst.ClassRoomCode, opt => opt.MapFrom(src => src.ClassRoomCode))
                .ForMember(dst => dst.ClassRoomName, opt => opt.MapFrom(src => src.ClassRoomName));

            CreateMap<API.Dtos.RequestDto.LessonDto, Lesson>();
            CreateMap<StudyProgramDto, StudyProgram>();
            CreateMap<SemesterDto, Semester>();

            CreateMap<StudentPersonalityInformation, PersonalInformationDto>()
                .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dst => dst.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.ToString()))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Student.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Student.LastName));

            CreateMap<StudentInformation, EducationInformationDto>()
                .ForMember(dst => dst.AdvisorTeacher,
                    opt => opt.MapFrom(src => src.AdvisorTeacher.FirstName + " " + src.AdvisorTeacher.LastName))
                .ForMember(dst => dst.StudyTime, opt => opt.MapFrom(src => src.StudyTime.Name))
                .ForMember(dst => dst.CurrentClass, opt => opt.MapFrom(src => src.Semester.Year.ToString()))
                .ForMember(dst => dst.EducationType, opt => opt.MapFrom(src => src.EducationType.ToString()))
                .ForMember(dst => dst.Semester, opt => opt.MapFrom(src => src.Semester.SemesterName))
                .ForMember(dst => dst.Faculty, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                .ForMember(dst => dst.StudyProgram, opt => opt.MapFrom(src => src.StudyProgram.ProgramName));

            CreateMap<Grade, GradeCardDto>()
                .ForMember(dst => dst.TeacherName,
                    opt => opt.MapFrom(x => x.Lesson.Teacher.FirstName + x.Lesson.Teacher.LastName))
                .ForMember(dst => dst.Akts, opt => opt.MapFrom(src => src.Lesson.Akts))
                .ForMember(dst => dst.GradesAverage, opt => opt.MapFrom(src => src.Average))
                .ForMember(dst => dst.LessonCode, opt => opt.MapFrom(src => src.Lesson.LessonCode))
                .ForMember(dst => dst.LessonName, opt => opt.MapFrom(src => src.Lesson.LessonName))
                .ForMember(dst => dst.PracticeTime, opt => opt.MapFrom(src => src.Lesson.PracticeTime))
                .ForMember(dst => dst.TheoryTime, opt => opt.MapFrom(src => src.Lesson.TheoryTime))
                .ForMember(dst => dst.Letter, opt => opt.MapFrom<LetterResolver>())
                .ForMember(dst => dst.LetterGrade, opt => opt.MapFrom<LetterGradeResolver>())
                .ForMember(dst => dst.Semester, opt => opt.MapFrom(src => src.Lesson.Semester.Id))
                .ForMember(dst => dst.LessonYear, opt => opt.MapFrom(src => src.Lesson.Semester.Year));

        }
    }
}
