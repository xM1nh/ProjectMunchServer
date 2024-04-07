using ProjectMunch.Models;

namespace ProjectMunch.Domain
{
    public interface IPointOfInterestService
    {
        Task<List<PointOfInterest>> GetAll();
        Task<PointOfInterest?> GetById(int id);
        Task<List<PointOfInterest>> GetByDistanceFromCenter(
            short longitude,
            short latitude,
            int distance
        );
        Task<bool> Add(short longitude, short latitude, string name, string? description);
    }
}
