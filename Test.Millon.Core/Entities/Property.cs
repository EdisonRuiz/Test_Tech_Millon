using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Millon.Core.Entities;

public partial class Property
{
    [Key]
    public Guid IdProperty { get; set; }

    public int IdOwner { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [StringLength(20)]
    public string CodeInternal { get; set; } = null!;

    public short Year { get; set; }

    [ForeignKey("IdOwner")]
    [InverseProperty("Properties")]
    public virtual Owner IdOwnerNavigation { get; set; } = null!;

    [InverseProperty("IdPropertyNavigation")]
    public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();

    [InverseProperty("IdPropertyNavigation")]
    public virtual ICollection<PropertyTrace> PropertyTraces { get; set; } = new List<PropertyTrace>();
}
