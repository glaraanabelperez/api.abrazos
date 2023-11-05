using Abrazos.ServiceEventHandler.Commands;
using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class ProfileDancerCreateCommand
    {
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public double Height { get; set; }

    }
}