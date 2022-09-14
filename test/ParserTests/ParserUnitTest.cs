using Xunit;
using EANExtractor;

namespace ParserTests;

public class ParserFixture
{

    public ParserFixture()
    {
        string EANdataStr = new EANdata().bigStr;
        this.parser = new Parser(EANdataStr);
        this.rawData = this.parser.getRawData();
        this.jsonData = this.parser.stringToJson(this.rawData);
    }  

    public Parser parser {get; set;}   
    public string rawData {get; set;}   
    public dynamic jsonData {get; set;}   
}

public class ParserUnitTest : IClassFixture<ParserFixture>
{
    ParserFixture fixture;

    public ParserUnitTest(ParserFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void getRawDataStringTest()
    {   
        Assert.Equal(typeof(string), this.fixture.rawData.GetType());

    }

    [Fact]
    public void getRawDataStringIsNotEmptyTest()
    {   
        Assert.True(!string.IsNullOrEmpty(this.fixture.rawData));
    }

    [Fact]
    public void stringToJsonTest()
    {

        Assert.Equal(typeof(Newtonsoft.Json.Linq.JObject), this.fixture.jsonData.GetType());
    }

    [Fact]
    public void stringToJsonDataTest()
    {
        dynamic data = this.fixture.jsonData;
        
        Assert.True(data.Product != null);
                
        dynamic product = data.Product;

        // test product data 
        Assert.True(product.ProductId != null);
        Assert.True(product.Title != null);
        Assert.True(product.BrandTitle != null);

        // test product data strings
        Assert.Equal("3600523924226", product.ProductId.ToString());
        Assert.Equal("Праймер для лица Infaillible Supergrip", product.Title.ToString());
        Assert.Equal("Infaillible", product.BrandTitle.ToString());
    }


}