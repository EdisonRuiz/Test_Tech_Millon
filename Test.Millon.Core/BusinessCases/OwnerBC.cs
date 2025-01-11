using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Core.BusinessCases
{
    public class OwnerBC
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerBC(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateOwner(Owner model)
        {
            await _unitOfWork.Owners.AddAsync(model);
            await _unitOfWork.CompleteAsync();
            return model.IdOwner;
        }

        public async Task<string> UpdateOwner(Owner model)
        {
            var entity = await GetByIdAsync(model.IdOwner);
            if (entity == null) return "Property not found";

            //Owners
            //Validation Rules don't allowed empty
            if (!String.IsNullOrEmpty(model.Name))
                entity.Name = model.Name;
            if (!String.IsNullOrEmpty(model.Address))
                entity.Address = model.Address;
            if (!String.IsNullOrEmpty(model.Address))
                entity.Address = model.Address;
            await _unitOfWork.CompleteAsync();
            return "It was Updated ";
        }

        private async Task<Owner> GetByIdAsync(int id)
            => await _unitOfWork.Owners.GetByIdAsync(id);
    }
}
