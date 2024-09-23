using System.Collections.Generic;
using MandrilApi.Models;
using MandrilApi.Services;
using Microsoft.AspNetCore.Mvc;
using MandrilApi.Helpers;

namespace MandrilApi.Controllers;

[ApiController]
[Route("api/madril/{mandrilId}/[controller]")]
public class AbilityController : ControllerBase
{
    //Get All The Abilities
    [HttpGet]
    public ActionResult<IEnumerable<Ability>> GetAbilities(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);
        return Ok(mandril.Abilities);
    }

    //Get Specific Ability
    [HttpGet("{AbilityId}")]
    public ActionResult<Ability> GetAbility(int mandrilId, int AbilityId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);


        var ability = mandril.Abilities?.FirstOrDefault(h => h.Id == AbilityId);
        if (ability == null)
            return NotFound(Messages.Ability.NotFound);

        return Ok(ability);
    }

    
    //Post a new Ability
    [HttpPost("{AbilityId}")]
    public ActionResult<Ability> PostAbility(int mandrilId ,AbilityInsert abilityInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var abilityExists = mandril.Abilities?.FirstOrDefault(h => h.Name == abilityInsert.Name);
        
        if (abilityExists == null)
            return BadRequest(Messages.Ability.Exists);

        var maxAbility = mandril.Abilities.Max(h => h.Id);

        var newAbility = new Ability(){
            Id = maxAbility + 1,
            Name = abilityInsert.Name,
            Potency = abilityInsert.Potency
        };

        mandril.Abilities.Add(newAbility);

        return CreatedAtAction(nameof(GetAbility),
        new {mandril = mandrilId, abilityId = newAbility.Id}, newAbility);
    }

    //Modify a Ability
    [HttpPut("{AbilityId}")]
    public ActionResult<Ability> PutAbility(int mandrilId, int AbilityId, AbilityInsert abilityInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var abilityExists = mandril.Abilities?.FirstOrDefault(h => h.Name == abilityInsert.Name);

        if(abilityExists == null)
            return NotFound(Messages.Ability.NotFound);

        var abilitySameName = mandril.Abilities?.FirstOrDefault(h => h.Id != AbilityId && h.Name == abilityInsert.Name);
        if(abilitySameName != null)
           return BadRequest(Messages.Ability.Exists);

        abilityExists.Name = abilityInsert.Name;
        abilityExists.Potency = abilityInsert.Potency;

        return NoContent();

    }

    //Delete a Ability
    [HttpDelete("{AbilityId}")]
    public ActionResult<Ability> DeleteAbility(int mandrilId, int AbilityId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var abilityExists = mandril.Abilities?.FirstOrDefault(h => h.Id == AbilityId);
        if(abilityExists == null)
            return NotFound(Messages.Ability.NotFound);

        mandril.Abilities?.Remove(abilityExists);
        return NoContent();
    }

}
