

using Models;

namespace Abrazos.Services.Dto
{
    public class TypeEventDto
    {
        public int TypeEventId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<TypeEvent_User>? TypeEventsUsers { get; set; } = new List<TypeEvent_User>();
    }
}