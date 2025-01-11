using Microsoft.EntityFrameworkCore;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Infraestructure.Percistences.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
