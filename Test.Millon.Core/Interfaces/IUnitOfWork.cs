using Test.Millon.Core.Entities;

namespace Test.Millon.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Property> Properties { get; }
        IRepository<Owner> Owners { get; }
        IRepository<PropertyImage> PropertyImages { get; }
        IRepository<PropertyTrace> PropertyTraces { get; }
        IPropertyRepository PropertyRepository { get; }
        Task<int> CompleteAsync();
    }
}
