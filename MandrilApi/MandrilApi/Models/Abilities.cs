namespace MandrilApi.Models;

public class Abilities
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public EPotency Potency { get; set; }
    public enum EPotency
    {
        Soft,
        Moderated,
        Intense,
        VeryIntense,
        Extreme
    }
}
