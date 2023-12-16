using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Ibge.Blazor.Service.Dtos;

public class IbgeDto
{
    [Column("Id", TypeName = "CHAR(7)")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Id is required.")]
    public string Id { get; set; } = String.Empty;

    [Column("State", TypeName = "CHAR(2)")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "The State must be exactly 2 characters long")]
    public string? State { get; set; } = String.Empty;

    [Column("City", TypeName = "NVARCHAR(80)")]
    [StringLength(50, ErrorMessage = "Maximum 30 characters")]
    public string? City { get; set; } = String.Empty;
}