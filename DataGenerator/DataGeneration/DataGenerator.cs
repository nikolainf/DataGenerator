using DataGenerator.RequestParsing;
using Newtonsoft.Json.Linq;

namespace DataGenerator.DataGeneration;
public class JsonDataGenerator
{
    public string Generate(ParsingResult parsingResult)
    {
        JObject jObject = new(
            new JArray(from props in parsingResult.Properties))
    }
}
