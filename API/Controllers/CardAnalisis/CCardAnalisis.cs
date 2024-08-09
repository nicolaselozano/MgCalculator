using CardsJson;
using Microsoft.AspNetCore.Mvc;

namespace CCardAnalisis.Controller;

[ApiController]
[Route("api/[controller]")]
public class CCardAnalisis : ControllerBase
{
    readonly CardsAnalisis _cardsAnalisis;
    public CCardAnalisis(CardsAnalisis cardsAnalisis)
    {
        _cardsAnalisis = cardsAnalisis;
    }
    [HttpGet]
    public IActionResult GetDetailsCard(string cardId,string key,string urlService)
    {
        try
        {
            TextDocument textDocument = _cardsAnalisis.GetTextDocument(cardId,key,urlService);
            
            return Ok(textDocument);
        }
        catch (System.Exception e)
        {
            return BadRequest("Get DeatilsCard Bad Request :" + e.Message);
            throw;
        }
    }
}