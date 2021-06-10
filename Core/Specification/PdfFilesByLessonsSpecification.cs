using Core.Entities;

namespace Core.Specification
{
    public class PdfFilesByLessonsSpecification : BaseSpecification<PdfFile>
    {
        public PdfFilesByLessonsSpecification(string lessonCode) : base(src => src.LessonCode == lessonCode)
        {
            
        }
    }
}
