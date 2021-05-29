using API.Dtos.ResponseDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class LetterGradeResolver : IValueResolver<Grade,GradeCardDto,double?>
    {
        public double? Resolve(Grade source, GradeCardDto destination, double? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(destination.Letter))
            {
                switch (destination.Letter)
                {
                    case "AA":
                        destination.LetterGrade = 4.0;
                        break;
                    case "AB":
                        destination.LetterGrade = 3.5;
                        break;
                    case "BB":
                        destination.LetterGrade = 3.0;
                        break;
                    case "BC":
                        destination.LetterGrade = 2.5;
                        break;
                    case "CC":
                        destination.LetterGrade = 2.0;
                        break;
                    case "DD":
                        destination.LetterGrade = 1.5;
                        break;
                    case "FD":
                        destination.LetterGrade = 1.0;
                        break;
                    case "FF":
                        destination.LetterGrade = 0;
                        break;
                    default:
                        destination.LetterGrade = 0;
                        break;
                }
            }

            return destination.LetterGrade;
        }
    }
}
