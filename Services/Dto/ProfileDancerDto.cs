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
        public DanceRol? DanceRol { get; set; }
        public DanceLevel? DanceLevel { get; set; }

        //public ICollection<User>? Users;

    }
}