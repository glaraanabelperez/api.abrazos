

namespace Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public ICollection<UserLanguage>? Userlanguages { get; set; } = new List<UserLanguage>();

    }
}