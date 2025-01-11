using Microsoft.EntityFrameworkCore;
using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Infraestructure.Percistences.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly TestMillonContext _context;
        public PropertyRepository(TestMillonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetAllByFilters(string codeInternal, decimal? price, short? year)
        {
            IQueryable<Property> query = _context.Properties;

            if (year.HasValue)
                query = query.Where(p => p.Year == year.Value);

            if (!string.IsNullOrEmpty(codeInternal))
                query = query.Where(p => p.CodeInternal == codeInternal);

            if (price.HasValue)
                query = query.Where(p => p.Price == price.Value);
            return await query.ToListAsync();
        }
    }
}
