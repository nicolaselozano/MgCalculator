using Cards.Models;
using Cards.Services;
using CardsUsers.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cards.Controller;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    readonly ICardS _cardService;
    public CardsController(ICardS cardservice)
    {
        _cardService = cardservice;
    }
    [HttpGet]
    public IActionResult GetCardUser(string cardId,string email)
    {
        try
        {
            Card card = _cardService.GetCardUser(cardId,email);

            return Ok(card);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error GetCardUser : " + e);
            throw;
        }
    }
    [HttpGet("all")]
    public IActionResult GetAllCardsUser(string email)
    {
        try
        {
            ICollection<Card> allCards = _cardService.GetAllCardUser(email);

            return Ok(allCards);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error GetAllCardsUser : " + e);
            throw;
        }
    }
    [HttpGet("select")]
    public IActionResult SelectCardsUser(string email,[FromQuery] List<string> cardList)
    {
        try
        {
            ICollection<Card> selectCards = _cardService.GetCardsUser(email,cardList);

            return Ok(selectCards);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error SelectCardsUser : " + e);
            throw;
        }
    }
    [HttpPost]
    public IActionResult PostCards([FromQuery] List<Card> cardList)
    {
        try
        {
            ICollection<Card> AddCards = _cardService.AddCards(cardList);

            return Ok(AddCards);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error PostCards : " + e);
            throw;
        }
    }
    [HttpPost("user")]
    public IActionResult PostCardsToUser(string email,[FromQuery] List<string> cardList)
    {
        try
        {
            ICollection<CardsUser> cardsUser = _cardService.AddCardsToUser(email,cardList);

            return Ok(cardsUser);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error PostCardsToUser : " + e);
            throw;
        }
    }
    [HttpPut]
    public IActionResult UpdateCardsUser([FromBody]List<Card> cardList)
    {
        try
        {
            ICollection<Card> updatedCards = _cardService.UpdateCardsUser(cardList);

            return Ok(updatedCards);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error UpdateCardsUser : " + e);
            throw;
        }
    }
    [HttpDelete]
    public IActionResult DeleteCardsUser(string email,[FromQuery] ICollection<string> cardIdList)
    {
        try
        {
            string responseDelete = _cardService.DeleteCardsUser(email,cardIdList);

            return Ok(responseDelete);
        }
        catch (System.Exception e)
        {
            return BadRequest("Error DeleteCardsUser : " + e);
            throw;
        }
    }
}