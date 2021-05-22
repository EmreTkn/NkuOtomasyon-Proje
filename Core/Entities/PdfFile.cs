using Core.Entities.Identity;

namespace Core.Entities
{
    public class PdfFile
    {
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Lesson Lesson { get; set; }
    }
}
