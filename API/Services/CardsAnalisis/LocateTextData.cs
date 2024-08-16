using CardsJson;

interface ILocateTextData
{  
    public string LocateText(TextDocument allLines);
}
public class LocateTextData: ILocateTextData
{
    public string LocateText(TextDocument allLines)
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
}