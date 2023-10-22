﻿namespace Models
{
    public class DanceLevel
    {
        public int DanceLevelId { get; set; }
        public int Name { get; set; }
        public ICollection<ProfileDancer> ProfileDancers { get; set; } = new List<ProfileDancer>();
    }
}