
using CardsJson;

namespace CardsAnalisisN.Service;
public static class OrderTextData
{
    
    public static Func<Line,string> Titulo()
    {
        return lineText => lineText.Text;
    }
    public static Func<List<Line>, string> Descripcion()
    {
        return lineTextList =>
        {
            string textLines = "";

            foreach (var line in lineTextList)
            {
                textLines += line.Text;
            }

            return textLines;
        };
    }
}