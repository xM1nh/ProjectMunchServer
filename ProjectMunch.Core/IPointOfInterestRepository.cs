using System.Linq.Expressions;
using ProjectMunch.Models;

namespace ProjectMunch.Domain
{
    public interface IPointOfInterestRepository
    {
        Task<List<PointOfInterest>> GetAll();
        Task<PointOfInterest?> Get(int id);
        Task<List<PointOfInterest>> GetByDistanceFromCenter(PointOfInterest center, int distance);
        Task<bool> Add(PointOfInterest poi);
        Task<IEnumerable<PointOfInterest>> Find(Expression<Func<PointOfInterest, bool>> predicate);
    }
}
