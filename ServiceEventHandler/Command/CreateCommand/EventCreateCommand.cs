using ServiceEventHandler.Command.UpdateCommand;
using ServiceEventHandler.Validators;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class EventCreateCommand
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El valor de AplicationId debe ser mayor que cero.")]
        public int UserIdCreator { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; }
        public string? Image { get; set; }
        public int? AddressId { get; set; }

        [ValidateDateTimeRangeAtributte(ErrorMessage = "Las fechas en el campo DateTimes no son válidas.")]
        public List<RangedateCreate> dateTimes { get; set; } 

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El valor de EventStateId debe ser mayor que cero.")]
        public int EventStateId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El valor de TypeEventId debe ser mayor que cero.")]
        public int TypeEventId{ get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El valor de RolId debe ser mayor que cero.")]
        public int RolId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El valor de Level debe ser mayor que cero.")]
        public int LevelId { get; set; }
        public int? Cupo { get; set; }
        [Required]
        public bool Couple { get; set; }

        public AddressUpdateCommand? Address { get; set; }

    }

    public class RangedateCreate
    {
        public DateTime dateInit { get; set; }
        public DateTime dateFinish { get; set; }

    }
}