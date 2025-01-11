namespace Test.Millon.API.Models.Dtos
{
    public class PropertyTraceDTO
    {
        public int IdPropertyTrace { get; set; }
        public Guid IdProperty { get; set; }
        public DateOnly DateSale { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public short Tax { get; set; }
    }
}
