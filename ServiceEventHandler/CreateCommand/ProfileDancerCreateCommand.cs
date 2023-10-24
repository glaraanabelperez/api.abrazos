using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class ProfileDancerCreateCommand
    {
        [Required]
        public int DanceLevel_FK { get; set; }
        [Required]
        public int DanceRol_FK { get; set; }
        public decimal Height { get; set; }
       
    }
}