using MandrilApi.Services;
using Microsoft.AspNetCore.Mvc;
using MandrilApi.Models;

namespace MandrilApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    //Todos los mandrriles
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok(MandrilDataStore.Current.Mandriles);
    }

    //Mandril especifico
    [HttpGet("{mandrilId}")]
    public ActionResult<IEnumerable<Mandril>> GetMandril(int mandrilId)
    {
       var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
       if (mandril == null)
        return NotFound("Mandril not found");
       return Ok(mandril);
    }

    //Añadir mandriles
    [HttpPost("{mandrilId}")]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
    {
        var MaxMandril = MandrilDataStore.Current.Mandriles.Max(x => x.Id);
        var newMandril = new Mandril()
        {
            Id = MaxMandril + 1,
            Name = mandrilInsert.Name,
            LastName = mandrilInsert.LastName
        };
        MandrilDataStore.Current.Mandriles.Add(newMandril);

        return CreatedAtAction(nameof(GetMandril),
            new {mandriId = newMandril.Id},
            newMandril
        );
            
    }

    //Modificar variables
    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> PutMandril([FromRoute] int mandrilId, [FromBody] MandrilInsert mandrilInsert)
    {
       var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
       if(mandril == null)
            return NotFound("Mandril not found");
        mandril.Name = mandrilInsert.Name;
        mandril.LastName = mandrilInsert.LastName;

        return NoContent();
    }

    //Eliminar Datos
    [HttpDelete("{mandrilId}")]
    public ActionResult<Mandril> DeleteMandril(int mandrilId)
    {
       var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
       if(mandril == null)
            return NotFound("Mandril not found");

        MandrilDataStore.Current.Mandriles.Remove(mandril);
        return NoContent();
               
    }
}
