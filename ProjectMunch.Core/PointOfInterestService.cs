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

        public async Task<List<PointOfInterest>> GetAllInDistanceFromCenter(PointOfInterest center, int distance)
        {
            return await _repository.GetAllInDistanceFromCenter(center, distance);
        }
    }
}
