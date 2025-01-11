using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Millon.Core.Entities;

public partial class PropertyTrace
{
    [Key]
    public int IdPropertyTrace { get; set; }

    public Guid IdProperty { get; set; }

    public DateOnly DateSale { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    public string Value { get; set; } = null!;

    public short Tax { get; set; }

    [ForeignKey("IdProperty")]
    [InverseProperty("PropertyTraces")]
    public virtual Property IdPropertyNavigation { get; set; } = null!;
}
