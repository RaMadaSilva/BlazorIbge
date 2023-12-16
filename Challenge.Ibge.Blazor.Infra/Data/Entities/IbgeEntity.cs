using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Ibge.Blazor.Infra.Data.Entities;

[Table("IBGE", Schema = "dbo")]
public class IbgeEntity
{
    [Column("Id", TypeName = "CHAR(7)")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Id is required.")]
    public string Id { get; set; } = String.Empty;

    [Column("State", TypeName = "CHAR(2)")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "The State must be exactly 2 characters long")]
    public string? State { get; set; } = String.Empty;
        
    [Column("City", TypeName = "NVARCHAR(80)")]
    public string? City { get; set; } = String.Empty;
}