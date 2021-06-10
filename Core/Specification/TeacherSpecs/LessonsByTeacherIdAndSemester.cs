using Core.Entities;

namespace Core.Specification.TeacherSpecs
{
    public class LessonsByTeacherIdAndSemester : BaseSpecification<Lesson>
    {
        public LessonsByTeacherIdAndSemester(string teacherId) : 
            base(src => src.Teacher.Id == teacherId)
        {
            AddInclude(src => src.Teacher);
            AddOrderBy(src => src.Semester.Id);
        }
        public LessonsByTeacherIdAndSemester(string teacherId,int semesterId) :
            base(src => src.Teacher.Id == teacherId && src.Semester.Id == semesterId)
        {
            AddInclude(src => src.Teacher);
            AddOrderBy(src => src.Semester.Id);
        }


    }
}
