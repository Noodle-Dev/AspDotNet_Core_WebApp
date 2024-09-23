namespace MandrilApi.Models;

public class Mandril
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;

    public List<Ability>? Abilities   { get; set; } = new List<Ability>();
}
