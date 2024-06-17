using Models;
using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Validators;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.UpdateCommand
{
    public class EventUpdateCommand
    {
        public int EventId { get; set; }
        public int? UserIdCreator { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? AddressId { get; set; }

        [ValidateDateTimeAtributte(ErrorMessage = "Las fechas en el campo DateTimes no son válidas.")]
        public RangedateUpdate dateTimes { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "El valor estado debe ser mayor que cero.")]
        public int? EventStateId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "El valor del Typo de evento debe ser mayor que cero.")]
        public int? TypeEventId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "El valor del Rol  debe ser mayor que cero.")]
        public int? RolId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "El valor del Nivel debe ser mayor que cero.")]
        public int? LevelId { get; set; }
        public int? Cupo { get; set; }
        public bool? Couple { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "El valor Ciclo debe ser mayor que cero.")]
        public int? CycleId { get; set; }

        public AddressUpdateCommand? Address { get; set; }

    }
    public class RangedateUpdate
    {
        public DateTime? dateInit { get; set; }
        public DateTime? dateFinish { get; set; }

    }


}