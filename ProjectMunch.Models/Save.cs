namespace ProjectMunch.Models
{
    public class Save
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int PointOfInterestId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
