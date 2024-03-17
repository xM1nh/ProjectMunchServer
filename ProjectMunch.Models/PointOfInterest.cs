using NetTopologySuite.Geometries;

namespace ProjectMunch.Models
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = null!;
        public required Point Coordinate { get; set; }
    }
}
