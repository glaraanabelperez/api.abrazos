using Models;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class DanceRolDto
    {
        public int DanceRolId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProfileDancer>? ProfileDancers { get; set; } = new List<ProfileDancer>();

    }
}