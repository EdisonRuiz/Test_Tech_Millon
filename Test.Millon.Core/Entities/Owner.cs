using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Millon.Core.Entities;

public partial class Owner
{
    [Key]
    public int IdOwner { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }

    public DateOnly Birthday { get; set; } 

    [InverseProperty("IdOwnerNavigation")]
    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
