using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LessonStatusResolver : IValueResolver<Grade,CurriculumGradeCardDto,LessonStatus>
    {
        public LessonStatus Resolve(Grade source, CurriculumGradeCardDto destination, LessonStatus destMember,
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
