namespace Test.Millon.API.Models.Dtos
{
    public class OwnerDTO
    {
        public string NameOwner { get; set; } = null!;
        public string AddressOwner { get; set; } = null!;
        //public byte[]? Photo { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
