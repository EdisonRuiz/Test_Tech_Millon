using Microsoft.AspNetCore.Mvc;
using Test.Millon.API.Models.Dtos;
using Test.Millon.Core.BusinessCases;
using AutoMapper;
using Test.Millon.Core.Entities;

namespace Test.Millon.API.Services
{
    public class InterfaceAdapter
    {
        private readonly PropertyBC _propertyBC;
        private readonly OwnerBC _ownerBC;
        private readonly IMapper _mapper;

        public InterfaceAdapter(PropertyBC propertyBC, IMapper mapper, OwnerBC ownerBC)
        {
            _mapper = mapper;
            _propertyBC = propertyBC;
            _ownerBC = ownerBC;
        }

        public async Task<string> CreatePropertyBuilding([FromBody] PropertyBuildingDTO model)
        {
            int idOwner = await _ownerBC.CreateOwner(_mapper.Map<Owner>(model));
            Property entity = _mapper.Map<Property>(model);
            entity.IdOwner = idOwner;
            entity.IdProperty = Guid.NewGuid();
            await _propertyBC.CreateProperty(entity);
            return "It was created your id is: " + entity.IdProperty;
        }

        public async Task<string> AddImageFromProperty([FromBody] PropertyImageDTO model) 
            => await _propertyBC.AddImageFromProperty(_mapper.Map<PropertyImage>(model));

        internal async Task<string> ChangePrice(ChangePriceDTO model) 
            => await _propertyBC.ChangePrice(model.IdProperty, model.Price);

        internal async Task<string> UpdateProperty(Guid id, PropertyBuildingDTO model)
        {
            Property entity = _mapper.Map<Property>(model);
            entity.IdProperty = id;
            int idOwner = await _propertyBC.UpdateProperty(entity);

            Owner owner = _mapper.Map<Owner>(model);
            owner.IdOwner = idOwner;
            return await _ownerBC.UpdateOwner(owner);
        }

        internal async Task<IEnumerable<Property>> ListPropertyWithFilters(string filters) 
            => await _propertyBC.ListPropertyWithFilters(filters);
    }
}
