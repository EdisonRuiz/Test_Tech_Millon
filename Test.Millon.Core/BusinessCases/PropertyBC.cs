using System.Text.Json;
using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Core.BusinessCases
{
    public class PropertyBC
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyBC(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProperty(Property model)
        {
            if (model.IdOwner == default(int)) throw new ArgumentNullException(nameof(model));
            await _unitOfWork.Properties.AddAsync(model);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<string> AddImageFromProperty(PropertyImage model)
        {
            bool exist = await ExistByIdAsync(model.IdProperty);
            if (!exist) return "Property not found";

            await _unitOfWork.PropertyImages.AddAsync(model);
            await _unitOfWork.CompleteAsync();
            return "An image was added to the property";
        }

        public async Task<string> ChangePrice(Guid id, decimal price)
        {
            bool exist = await ExistByIdAsync(id);
            if (!exist || price < default(int)) return "Property not found || price doesn't less that zero";

            var entity = await _unitOfWork.Properties.GetByIdAsync(id);
            entity.Price = price;
            await _unitOfWork.CompleteAsync();
            return "Price was changed";
        }

        public async Task<IEnumerable<Property>> ListPropertyWithFilters(string filters)
        {
            if (String.IsNullOrEmpty(filters))
                return await _unitOfWork.Properties.GetAllAsync();

            Dictionary<string, string> filter = JsonSerializer.Deserialize<Dictionary<string, string>>(filters);

            return await _unitOfWork.PropertyRepository.GetAllByFilters(filter?["codeInternal"]?? string.Empty
                , decimal.Parse(filter?["price"] ?? string.Empty), short.Parse(filter?["year"]?? string.Empty));
        }

        public async Task<int> UpdateProperty(Property model)
        {
            Property entity = await GetByIdAsync(model.IdProperty);
            if (entity == null) return default(int);

            //Properties
            //Validation Rules don't allowed empty 
            if (model.Year > default(short))
                entity.Year = model.Year;
            if (!String.IsNullOrEmpty(model.Address))
                entity.Address = model.Address;
            if (model.Price > default(short))
                entity.Price = model.Price;
            if (!String.IsNullOrEmpty(model.CodeInternal))
                entity.CodeInternal = model.CodeInternal;
            if (!String.IsNullOrEmpty(model.Name))
                entity.Name = model.Name;

            await _unitOfWork.CompleteAsync();
            return entity.IdOwner;
        }

        private async Task<bool> ExistByIdAsync(Guid id) 
            => await _unitOfWork.Properties.GetByIdAsync(id) != null;

        private async Task<Property> GetByIdAsync(Guid id) 
            => await _unitOfWork.Properties.GetByIdAsync(id);
    }
}
