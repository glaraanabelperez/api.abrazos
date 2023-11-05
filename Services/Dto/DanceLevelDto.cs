using Models;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class DanceLevelDto 
    {
        public int DanceLevelId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProfileDancerDto> ProfileDancers { get; set; } = new List<ProfileDancerDto>();

    }
}