using static MandrilApi.Models.Ability;

namespace MandrilApi.Models;

public class AbilityInsert
{
    public string Name { get; set; } = string.Empty;
    
    public EPotency Potency { get; set; }
}
