using Models;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class ProfileDancerDto
    {
        public int ProfileDanceId { get; set; }
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public decimal? Height { get; set; }
        public DanceRolDto? DanceRol { get; set; }
        public DanceLevelDto? DanceLevel { get; set; }

    }
}