using CardsAnalisisN.Service;
using CardsJson;
using Microsoft.AspNetCore.Mvc;

namespace CCardAnalisis.Controller;

[ApiController]
[Route("api/[controller]")]
public class CCardAnalisis : ControllerBase
{
    readonly ICardsAnalisis _cardsAnalisis;
    public CCardAnalisis(ICardsAnalisis cardsAnalisis)
    {
        _cardsAnalisis = cardsAnalisis;
    }
    [HttpGet]
    public ActionResult<TextDocument> GetDetailsCard (string imgUrl,string key,string urlService)
    {
        try
        {
            TextDocument textDocument = _cardsAnalisis.GetTextDocument(imgUrl,key,urlService);
            
            return Ok(textDocument);
        }
        catch (System.Exception e)
        {
            return BadRequest("Get DeatilsCard Bad Request :" + e.Message);
            throw;
        }
    }
}