using Test.Millon.Core.Entities;

namespace Test.Millon.Core.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllByFilters(string codeInternal, decimal? price = null, short? year = null); 
    }
}
