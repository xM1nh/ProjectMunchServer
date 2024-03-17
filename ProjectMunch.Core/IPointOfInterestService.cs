using ProjectMunch.Models;

namespace ProjectMunch.Domain
{
    public interface IPointOfInterestService
    {
        Task<List<PointOfInterest>> GetAll();
        Task<PointOfInterest?> GetById(int id);
        Task<List<PointOfInterest>> GetAllInDistanceFromCenter(PointOfInterest center, int distance);
    }
}
