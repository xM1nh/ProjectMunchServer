using NetTopologySuite.Geometries;
using ProjectMunch.Models;

namespace ProjectMunch.Domain
{
    public interface IPointOfInterestRepository
    {
        Task<List<PointOfInterest>> GetAll();
        Task<PointOfInterest?> Get(int id);
        Task<List<PointOfInterest>> GetAllInDistanceFromCenter(PointOfInterest center, int distance);
    }
}
