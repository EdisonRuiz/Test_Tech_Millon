using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;
using Test.Millon.Infraestructure.Percistences.Repositories;

namespace Test.Millon.Infraestructure.Percistences
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestMillonContext _context;

        private IRepository<Property> _properties;
        private IRepository<Owner> _owners;
        private IRepository<PropertyImage> _propertyImages;
        private IRepository<PropertyTrace> _propertyTraces;
        private IPropertyRepository _propertyRepository;

        public UnitOfWork(TestMillonContext context)
        {
            _context = context;
            _propertyRepository = new PropertyRepository(_context);
        }

        public IRepository<Property> Properties => _properties ??= new Repository<Property>(_context);

        public IRepository<Owner> Owners => _owners ??= new Repository<Owner>(_context);

        public IRepository<PropertyImage> PropertyImages => _propertyImages ??= new Repository<PropertyImage>(_context);

        public IRepository<PropertyTrace> PropertyTraces => _propertyTraces ??= new Repository<PropertyTrace>(_context);

        public IPropertyRepository PropertyRepository => _propertyRepository;

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
