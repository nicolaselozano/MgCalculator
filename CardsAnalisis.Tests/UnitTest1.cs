using Microsoft.Extensions.Configuration;
using Xunit;
using CardsAnalisisN.Service;

public class CardsAnalysisTests
{
    private readonly IConfiguration _config;

    public CardsAnalysisTests()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true) 
            .AddEnvironmentVariables()                        
            .Build();
    }

    [Fact]
    public void Test_GetTextDocument()
    {
        var service = new CardsAnalisis();
        var imgUrl = _config["IMAGE_URL"];
        var key = _config["API_KEY"];
        var urlService = _config["SERVICE_URL"];

        Assert.NotNull(imgUrl);
        Assert.NotNull(key);
        Assert.NotNull(urlService);

        System.Console.WriteLine($"IMAGE_URL: {imgUrl}");
        System.Console.WriteLine($"API_KEY: {key}");
        System.Console.WriteLine($"SERVICE_URL: {urlService}");

        var result = service.GetTextDocument(imgUrl, key, urlService);

        Assert.NotNull(result);
        Assert.NotEmpty(result.Lines);
    }
}
