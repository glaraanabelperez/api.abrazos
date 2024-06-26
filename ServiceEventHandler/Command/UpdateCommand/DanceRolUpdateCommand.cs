﻿using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class DanceRolUpdateCommand
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int DanceRolId { get; set; }
        [MaxLength(255)]
        public string? Name { get; set; } = null!;
    }
}
