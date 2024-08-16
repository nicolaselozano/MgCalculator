using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Cards.Models;
using CardsJson;
using ICardJson;

namespace CardsAnalisisN.Service;

public class CardsAnalisis : ICardsAnalisis
{
    public TextDocument GetTextDocument(string imgUrl,string key,string urlService)
    {
        try
        {
            ImageAnalysisClient client = new ImageAnalysisClient(
                new Uri(urlService),
                new AzureKeyCredential(key)
            );

            ImageAnalysisResult result = client.Analyze(
                new Uri(imgUrl),
                VisualFeatures.Read | VisualFeatures.Caption,
                new ImageAnalysisOptions{GenderNeutralCaption = true}
            );

            Console.WriteLine("Image analysis results:");
            Console.WriteLine(" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F1}");

            TextDocument textDocument = new TextDocument
            {
                Lines = new List<Line>()
            };

            foreach (DetectedTextBlock block in result.Read.Blocks)
            {
                foreach (DetectedTextLine line in block.Lines)
                {
                    Line customLine = new Line{
                        Text = line.Text,
                        BoundingPolygon = new List<BoundingPolygon>(),
                        // Words = new List<Word>()
                    };

                    foreach (var item in line.BoundingPolygon)
                    {
                        customLine.BoundingPolygon.Add(new BoundingPolygon{X = item.X,Y = item.Y});
                    }



                    Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");

                    textDocument.Lines.Add(customLine);
                }
            }

            return textDocument;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public CardApiJson GetCardApiData(TextDocument cardData)
    {
        try
        {
            return null;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}