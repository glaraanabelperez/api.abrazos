

namespace Models
{
    public class UserLanguage
    {
        public int UserLanguageId { get; set; }
        public int LanguageId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Language Language { get; set; }


    }
}