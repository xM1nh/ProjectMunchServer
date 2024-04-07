using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectMunch.Domain;
using ProjectMunch.Models;

namespace ProjectMunch.Persistence
{
    public class PointOfInterestRepository(MunchContext context) : IPointOfInterestRepository
    {
        private readonly MunchContext _context = context;

        public async Task<List<PointOfInterest>> GetAll()
        {
            return await _context.PointOfInterests.ToListAsync();
        }

        public async Task<PointOfInterest?> Get(int id)
        {
            return await _context.PointOfInterests.FindAsync(id);
        }

        public async Task<List<PointOfInterest>> GetByDistanceFromCenter(
            PointOfInterest center,
            int distance
        )
        {
            return await _context
                .PointOfInterests.Where(p => center.Coordinate.Distance(p.Coordinate) <= distance)
                .ToListAsync();
        }

        public async Task<bool> Add(PointOfInterest poi)
        {
            _context.PointOfInterests.Add(poi);
            var affected = await _context.SaveChangesAsync();

            if (affected == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PointOfInterest>> Find(
            Expression<Func<PointOfInterest, bool>> predicate
        )
        {
            return await _context.PointOfInterests.Where(predicate).ToListAsync();
        }
    }
}
