using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LetterResolver<T> : IValueResolver<Grade,T,string>
    {
        public string Resolve(Grade source, T destination, string destMember, ResolutionContext context)
        {
            if (source.Average != null)
            {
                switch (source.Average)
                {
                    case { } n when  n <= 100 && n >= 90:
                       return "AA";
                    case { } n when n <= 89 && n >= 80:
                        return "BA";
                    case { } n when n <= 79 && n >= 70:
                        return "BB";
                    case { } n when n <= 69 && n >= 65:
                        return "BC";
                    case { } n when n <= 64 && n >= 60:
                        return "CC";
                    case { } n when n <= 59 && n >= 50:
                        return "DD";
                    case { } n when n <= 49 && n >= 30:
                        return "FD";
                    case { } n when n <= 29 && n == 0:
                        return "FF";
                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
