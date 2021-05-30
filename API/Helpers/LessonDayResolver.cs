using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LessonDayResolver : IValueResolver<Lesson,LessonDateDto,LessonDay>
    {
        public LessonDay Resolve(Lesson source, LessonDateDto destination, LessonDay destMember, ResolutionContext context)
        {
            return source.LessonDay switch  //Lessonday değişmeli. Veri kaybından dolayı ertelendi unutma.
            {
                "Pazartesi" => LessonDay.Monday,
                "Sali" => LessonDay.Tuesday,
                "Çarşamba" => LessonDay.Wednesday,
                "Perşembe" => LessonDay.Thursday,
                "Cuma" => LessonDay.Friday,
                "Cumartesi" => LessonDay.Saturday,
                "Pazar" => LessonDay.Sunday,
                _ => LessonDay.Friday
            };
        }
    }
}
