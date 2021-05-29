using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LetterResolver : IValueResolver<Grade,GradeCardDto,string>
    {
        public string Resolve(Grade source, GradeCardDto destination, string destMember, ResolutionContext context)
        {
            if (source.Average != null)
            {
                switch (source.Average)
                {
                    case { } n when  n <= 100 && n >= 90:
                        destination.Letter = "AA";
                        break;
                    case { } n when n <= 89 && n >= 80:
                        destination.Letter = "BA";
                        break;
                    case { } n when n <= 79 && n >= 70:
                        destination.Letter = "BB";
                        break;
                    case { } n when n <= 69 && n >= 65:
                        destination.Letter = "BC";
                        break;
                    case { } n when n <= 64 && n >= 60:
                        destination.Letter = "CC";
                        break;
                    case { } n when n <= 59 && n >= 50:
                        destination.Letter = "DD";
                        break;
                    case { } n when n <= 49 && n >= 30:
                        destination.Letter = "FD";
                        break;
                    case { } n when n <= 29 && n == 0:
                        destination.Letter = "FF";
                        break;
                    default:
                        destination.Letter = null;
                        break;
                }
            }

            return destination.Letter;
        }
    }
}
