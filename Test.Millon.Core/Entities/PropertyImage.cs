using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Millon.Core.Entities;

public partial class PropertyImage
{
    [Key]
    public int IdPropertyImage { get; set; }

    public Guid IdProperty { get; set; }

    [Column(TypeName = "image")]
    public byte[] FileImage { get; set; } = null!;

    public bool Enabled { get; set; }

    [ForeignKey("IdProperty")]
    [InverseProperty("PropertyImages")]
    public virtual Property IdPropertyNavigation { get; set; } = null!;
}
