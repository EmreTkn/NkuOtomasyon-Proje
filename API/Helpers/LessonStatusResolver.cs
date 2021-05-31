using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LessonStatusResolver<T> : IValueResolver<Grade,T,LessonStatus> where T : GradeDto
    {
        public LessonStatus Resolve(Grade source, T destination, LessonStatus destMember,
            ResolutionContext context)
        {
            if (source.NumberOfLessonTaken != 0)
            {
                return source?.Average switch
                {
                    { } n when n >= 60 => LessonStatus.Success,
                    { } n when n < 60 && n >=0 => LessonStatus.Failed,
                    { } n when n == null => LessonStatus.Pending,
                    _ => LessonStatus.Pending
                };
            }
            return LessonStatus.Unregistered;
        }
    }
}
