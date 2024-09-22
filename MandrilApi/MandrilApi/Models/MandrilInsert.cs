
using System.ComponentModel.DataAnnotations;

namespace MandrilApi.Models;

public class MandrilInsert
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;
}
