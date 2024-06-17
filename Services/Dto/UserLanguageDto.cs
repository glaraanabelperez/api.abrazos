

namespace Models
{
    public class UserLanguageDto
    {
        public int UserLanguageId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }

        public int UserId { get; set; }
        public LanguageDto Language { get; set; }

    }
}