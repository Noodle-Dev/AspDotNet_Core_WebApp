using System.Collections.Generic;
using MandrilApi.Models;
using MandrilApi.Services;
using Microsoft.AspNetCore.Mvc;

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
            return NotFound("Mandril not found");
        return Ok(mandril.Abilities);
    }

    //Get Specific Ability
    [HttpGet("{AbilityId}")]
    public ActionResult<Ability> GetAbility(int mandrilId, int AbilityId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound("Mandril not found");


        var ability = mandril.Abilities?.FirstOrDefault(h => h.Id == AbilityId);
        if (ability == null)
            return NotFound("Ability not found");

        return Ok(ability);
    }

    /*
    //Post a new Ability
    [HttpPost]
    public ActionResult<Ability> PostAbility()
    {

    }

    //Modify a Ability
    [HttpPut]
    public ActionResult<Ability> PutAbility()
    {

    }

    //Delete a Ability
    [HttpDelete]
    public ActionResult<Ability> DeleteAbility()
    {

    }*/
}
