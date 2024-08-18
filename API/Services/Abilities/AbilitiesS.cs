using Cards.Models;
using CardsAnalisisN.Service;
using CardsJson;
using CardsUsers.Models;
using DatabaseR;
using ICardJson;


namespace Cards.Services;
public interface IAbilitiesS
{
    public Task<List<Abilitie>> GetAbilitiesCard(string url);
    public List<Abilitie> GetAbilities();
}

public class AbilitiesS : IAbilitiesS
{
    private readonly CardsApi _context;
    readonly ICardsAnalisis _cardsAnalisis;
    public AbilitiesS(CardsApi context, ICardsAnalisis cardsAnalisis)
    {
        _context = context;
        _cardsAnalisis = cardsAnalisis;
    }
    
    public List<Abilitie> GetAbilities()
    {
        try
        {
            List<Abilitie> abilities = _context.Abilities.Where(a => a.Name != null).ToList();

            return abilities;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public List<Abilitie> AddAbilities(List<Abilitie> listAbilities)
    {
        try
        {
            foreach (Abilitie abilitie in listAbilities)
            {
                Abilitie existA = _context.Abilities.FirstOrDefault(a => a.Name == abilitie.Name);

                if (existA == null)
                {
                    _context.Abilities.Add(abilitie);
                }
            }
            _context.SaveChanges();

            return listAbilities;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public async Task<List<Abilitie>> GetAbilitiesCard(string url)
    {
        try
        {
            TextDocument textDocument = _cardsAnalisis.GetTextDocument(url,"","");

            ILocateTextData locateTextData = new LocateTextData();

            string title = locateTextData.LocateTitleText(textDocument);

            CardApiJson cardApi = await _cardsAnalisis.GetCardApiData(title);
            
            List<Abilitie> abilitiesList = locateTextData.LocateDescriptionText(cardApi.Text,(splitTxt) => {
                
                List<Abilitie> abilities = GetAbilities();

                List<Abilitie> cardAbilites = new List<Abilitie>();

                foreach (Abilitie abilite in abilities)
                {
                    if (splitTxt.Any(t => t == abilite.Name))
                    {
                        cardAbilites.Add(abilite);
                    }
                }

                return cardAbilites;

            });

            return abilitiesList;

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

}