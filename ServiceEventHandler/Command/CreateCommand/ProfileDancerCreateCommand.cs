

using Models;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class ProfileDancerCreateCommand
    {
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public double Height { get; set; }

        public DanceRolCreateCommand? DanceRol { get; }
        public DanceLevelCreateCommand? DanceLevel { get; }
    }
}