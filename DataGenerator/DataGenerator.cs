using DataGenerator.RequestParsing;

namespace DataGenerator;
public static class Data
{
    public static string Generate(string dataRequest, DataType dataType = DataType.Json)
    {
        RequestParser parser = new(dataRequest);
        var properties = parser.Parse();

        throw new NotImplementedException();

    }
}
