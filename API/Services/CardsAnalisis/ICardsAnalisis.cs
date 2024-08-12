using CardsJson;
namespace CardsAnalisisN.Service;
public interface ICardsAnalisis
{
    TextDocument GetTextDocument(string imgUrl,string key,string urlService);
}