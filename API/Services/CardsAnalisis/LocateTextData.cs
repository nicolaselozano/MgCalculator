using CardsJson;
namespace CardsAnalisisN.Service;
interface ILocateTextData
{  
    public string LocateTitleText(TextDocument allLines);
    public List<T> LocateDescriptionText<T>(string textDescription,Func<string[],List<T>> strategy);
}
public class LocateTextData: ILocateTextData
{
    public string LocateTitleText(TextDocument allLines)
    {
        try
        {
            var getTitulo = OrderTextData.Titulo();
            string title = getTitulo(allLines.Lines.First());

            return title;

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public List<T> LocateDescriptionText<T>(string textDescription, Func<string[], List<T>> strategy)
    {
        try
        {
            string[] listText = textDescription.Split(" ");

            return strategy(listText);

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}