using CardsJson;
using ICardJson;
namespace CardsAnalisisN.Service;
public interface ICardsAnalisis
{
    TextDocument GetTextDocument(string imgUrl,string key,string urlService);
    CardApiJson  GetCardApiData(TextDocument cardData);
}