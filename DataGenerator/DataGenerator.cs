using DataGenerator.DataGeneration;
using DataGenerator.RequestParsing;

namespace DataGenerator;
public static class Data
{
    public static string Generate(string dataRequest, DataType dataType = DataType.Json)
    {
        RequestParser parser = new(dataRequest);
        var parsingResult = parser.Parse();

        DataGeneration.DataGenerator dataGenerator = new();
        var data = dataGenerator.Generate(parsingResult!);

        JsonDataGenerator jsonGenerator = new();
        var result = jsonGenerator.Generate(data);

        return result;
    }
}
