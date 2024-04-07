using NetTopologySuite.Geometries;
using ProjectMunch.Models;

namespace ProjectMunch.Domain
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly IPointOfInterestRepository _repository;

        public PointOfInterestService(IPointOfInterestRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            _repository = repository;
        }

        public async Task<List<PointOfInterest>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<PointOfInterest?> GetById(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<PointOfInterest>> GetByDistanceFromCenter(
            short longitude,
            short latitude,
            int distance
        )
        {
            var center = new PointOfInterest()
            {
                Name = "name",
                Coordinate = new(longitude, latitude)
            };

            return await _repository.GetByDistanceFromCenter(center, distance);
        }

        public async Task<bool> Add(
            short longitude,
            short latitude,
            string name,
            string? description
        )
        {
            var coordinate = new Point(longitude, latitude);
            var existing = await _repository.Find(p => p.Coordinate == coordinate);

            if (existing.Any())
            {
                return false;
            }

            var poi = new PointOfInterest()
            {
                Coordinate = coordinate,
                Name = name,
                Description = description ?? ""
            };

            var affected = await _repository.Add(poi);

            return affected;
        }
    }
}
