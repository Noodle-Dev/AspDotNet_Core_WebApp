using MandrilApi.Models;

namespace MandrilApi.Services;

public class MandrilDataStore
{
    public List<Mandril> Mandriles { get; set; }
    public static MandrilDataStore Current { get; } = new MandrilDataStore();
    public MandrilDataStore()
    {
        Mandriles = new List<Mandril>()
        {
            new Mandril()
            {
                Id = 1,
                Name = "Mini Mandril",
                LastName = "Rodriguez",
                Abilities = new List<Ability>()
                {
                    new Ability()
                    {
                        Id = 1,
                        Name = "Saltar",
                        Potency = Ability.EPotency.Moderated
                    }
                }
            },
            new Mandril()
            {
                Id = 2,
                Name = "Supermandril",
                LastName = "Fernandez",
                Abilities = new List<Ability>()
                {
                    new Ability()
                    {
                        Id = 1,
                        Name = "Saltar",
                        Potency = Ability.EPotency.Moderated
                    },
                    new Ability()
                    {
                        Id = 2,
                        Name = "Caminar",
                        Potency = Ability.EPotency.Intense
                    },
                    new Ability()
                    {
                        Id = 3,
                        Name = "Gritar",
                        Potency = Ability.EPotency.Extreme
                    }
                }
            },
            new Mandril()
            {
                Id = 3,
                Name = "Megamandril",
                LastName = "Legrand",
                Abilities = new List<Ability>()
                {
                    new Ability()
                    {
                        Id = 1,
                        Name = "Nadar",
                        Potency = Ability.EPotency.Intense
                    },
                    new Ability()
                    {
                        Id = 2,
                        Name = "Correr",
                        Potency = Ability.EPotency.Extreme
                    },
                    new Ability()
                    {
                        Id = 3,
                        Name = "Vomitar",
                        Potency = Ability.EPotency.Extreme
                    }
                }
            }
        };
    }
}
