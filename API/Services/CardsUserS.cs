using Cards.Models;
using CardsUsers.Models;
using DatabaseR;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Cards.Services;
public interface ICardS
{
    Card GetCardUser(string email,string cardId);
    ICollection<Card> GetAllCardUser(string email);
    ICollection<Card> GetCardsUser(string email,ICollection<string> cardIdList);
    ICollection<Card> AddCards(ICollection<Card> cardList);
    ICollection<CardsUser> AddCardsToUser(string email,ICollection<string> cardIdList);
    ICollection<Card> UpdateCardsUser(ICollection<Card> cardList);
    string DeleteCardsUser(string email,ICollection<string> cardIdList);
}

public class CardS : ICardS
{
    private readonly CardsApi _context;
    public CardS(CardsApi context)
    {
        _context = context;
    }
    public string DeleteCardsUser(string email,ICollection<string> cardIdList)
    {
        try
        {
            foreach (string cardId in cardIdList)
            {
                CardsUser cardsUsers = _context.CardsUsers.FirstOrDefault(cu => cu.User.Email == email && cu.Card.MultiverseId == cardId);
                _context.CardsUsers.Remove(cardsUsers);
            }
            _context.SaveChanges();

            return "Cards Removed";

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public ICollection<Card> UpdateCardsUser(ICollection<Card> cardList)
    {
        try
        {
            foreach (var card in cardList)
            {
                Card cardExist = _context.Cards.First(c => c.MultiverseId == card.MultiverseId);

                if (cardExist != null)
                {
                    cardExist.MultiverseId = card.MultiverseId;
                }

                if(card.Users.Count > 0)
                {
                    foreach (var user in card.Users)
                    {
                        AddCardsToUser(user.Email,[card.MultiverseId]);
                    }
                }

            }
            _context.SaveChanges();

            return cardList;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public ICollection<CardsUser> AddCardsToUser(string email,ICollection<string> cardIdList)
    {
        try
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);
            ICollection<CardsUser> cardsUsersList = [];

            foreach (string cardId in cardIdList)
            {
                Card card = _context.Cards.FirstOrDefault(c => c.MultiverseId == cardId);

                if(card !=null && user != null)
                {
                    CardsUser cardUser = new CardsUser
                    {
                        Card = card,
                        User = user,
                    };
                    _context.CardsUsers.Add(cardUser);
                    cardsUsersList.Add(cardUser);
                }
                else
                {
                    throw new Exception("User or Card not found");
                }
            }
            _context.SaveChanges();

            return cardsUsersList;

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public ICollection<Card> AddCards(ICollection<Card> cardList)
    {
        try
        {
            foreach (Card card in cardList)
            {
                Card cardExist = _context.Cards.FirstOrDefault(c => c.MultiverseId == card.MultiverseId);

                if (cardExist == null)
                {
                    _context.Cards.Add(card);
                }
            }
            _context.SaveChanges();

            return cardList;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public Card GetCardUser(string email,string cardId)
    {
        try
        {
            Card card = _context.Cards.Where(c => c.CardsUsers.Any(u => u.User.Email == email) && c.MultiverseId == cardId).FirstOrDefault();

            return card;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public ICollection<Card> GetAllCardUser(string email)
    {
        try
        {
            ICollection<Card> cards = _context.Cards.Where(c => c.Users.Any(u => u.Email == email)).ToList();

            return cards;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public ICollection<Card> GetCardsUser(string email,ICollection<string> cardIdList)
    {
        try
        {
            ICollection<Card> cards = [];
            foreach (string idCard in cardIdList)
            {
                Card card = _context.Cards
                .Include(c => c.Users)
                .FirstOrDefault(c => c.MultiverseId == idCard && c.Users.Any(u => u.Email == email));

                if(card != null)
                {
                    cards.Add(card);
                }
                else
                {
                    throw new Exception("Card Not found");
                }
            }

            return cards;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}