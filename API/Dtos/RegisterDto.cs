using System.ComponentModel.DataAnnotations;
using Core.Entities;


namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string SchoolNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password 1 Büyük Harf, 1 Küçük Harf, 1 Numara, 1 Alfanumerik Karakter içermeli ve En Az 6 Karakterden Oluşmalı.")]
        public string Password { get; set; }

        [Required]
        public Types Type { get; set; }
    }
}
