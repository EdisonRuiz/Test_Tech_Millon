namespace Test.Millon.API.Models.Dtos
{
    public class PropertyBuildingDTO : OwnerDTO
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public short Year { get; set; }
    }
}
